using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace BurgerBattler.Chara
{�@
    //�L�����N�^�[�I��p��Toggle�̃N���X
    public class CharaToggleGroupContorller : MonoBehaviour
    {
        List<Toggle> togglesList = new List<Toggle>();
        public CharaModel model;
        //[SerializeField] CharaDetail detail;
        [SerializeField] GameObject selectButton;


        private void Start()
        {
            model = new CharaModel(0); //������
        }

        public void SetToggleGroup()
        {
            var toggles = this.gameObject.GetComponentsInChildren<Transform>(); //�q��toggle��S���擾
            
            foreach (var toggle in toggles)
            {
                if (toggle.GetComponent<Toggle>() != null)
                {
                    togglesList.Add(toggle.GetComponent<Toggle>());
                    toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change);  //Change��onValueChange�ɐݒ�
                    toggle.GetComponent<Toggle>().group = GetComponent<ToggleGroup>(); //toggle��group������object�ɐݒ�
                }
            }
        }

        public void Change(bool state)
        {
            //�I�΂ꂽToggle�݂̂��Ăяo�����
            if (state)
            {
                foreach (var toggle in togglesList)
                {
                    //�I�΂ꂽToggle��������
                    if (toggle.isOn)
                    {
                        model = toggle.GetComponent<CharaController>().model; //model�ɑ��
                        toggle.transform.DOScale(Vector2.one * 1.1f, 0.1f).SetEase(Ease.OutBounce); //�傫���\��
                    }
                    //����ȊO��������
                    else
                    {
                        toggle.transform.DOScale(Vector2.one, 0.1f).SetEase(Ease.OutBounce);
                    }
                }
                selectButton.SetActive(true); //����{�^����\��
            }
        }
    }
}
