using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using BurgerBattler.Manager;
using BurgerBattler.Topping;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    //�쐬���Ă���o�[�K�[��Toggle�̃N���X
    public class BurgerTogglesGroupController : MonoBehaviour
    {
        [SerializeField] BurgerDecideButton decideButton; //������{�^��
        [SerializeField] BurgerCreateMotionController motion; //�o�[�K�[�̓������Ǘ�����N���X
        [SerializeField] CreateButtonBase createButton;  //����{�^��
        ToppingModel[] Toppings; //�g�b�s���O�̔z��


        Toggle activeToggle; //Toggle�̒��ŁA�I�����ꂽ����
        List<Toggle> togglesList; //Toggle�ꗗ

        private void Start()
        {
            Toppings = new ToppingModel[3];
            togglesList = new List<Toggle>();

            var toggles = this.gameObject.GetComponentsInChildren<Toggle>();

            //�q��toggle��onValueChanged��Change��ǉ�
            foreach (var toggle in toggles)
            {
                toggle.GetComponent<Image>().DOFade(0.2f, 1f).SetLoops(-1, LoopType.Yoyo);
                toggle.transform.DOScale(1.1f, 1.1f).SetLoops(-1, LoopType.Yoyo);

                togglesList.Add(toggle.GetComponent<Toggle>());
                toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change);

            }
            //activeToggle�ɏ����l��Active��Toggle��ݒ�
            activeToggle = gameObject.GetComponent<ToggleGroup>().ActiveToggles().First(); 
        }

        public void Change(bool state)
        {
            if (state)
            {
                activeToggle = this.gameObject.GetComponent<ToggleGroup>().ActiveToggles().First();

                foreach (var toggle in togglesList)
                {
                    if (toggle.isOn)
                    {
                        toggle.transform.DOPause();
                        toggle.transform.DOScale(Vector2.one * 1.5f, 0.3f).SetEase(Ease.InOutBack);
                        toggle.GetComponent<Image>().DOPause();
                        toggle.GetComponent<Image>().DOFade(1, 0.1f);
                        motion.CreateMode();
                    }
                    else
                    {
                        toggle.transform.localScale = Vector2.one;
                    }
                }
            }
        }

        //������model���o�[�K�[�ɃZ�b�g
        public void SetPlayerTopping(ToppingModel model)
        {
            Image toggleImage = activeToggle.GetComponent<Image>();
            toggleImage.sprite = model.icon;

            
            switch (activeToggle.name)
            {
                case "TopFood":
                    Toppings[0] = model;
                    break;

                case "MidFood":
                    Toppings[1] = model;
                    break;

                case "BotFood":
                    Toppings[2] = model;
                    break;
            }

            bool isNull = Toppings.Contains(null);

            //�n���o�[�K�[�����ׂăg�b�s���O�I���ς݂�������
            if (!isNull)
            {
                decideButton.gameObject.SetActive(true); //������{�^����\��
                createButton.BurgerCreate(Toppings); //BurgerCreate�ɑI���g�b�s���O�ꗗ��n��
            }
        }
    }
}
