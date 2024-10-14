using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BurgerBattler.Topping;

namespace BurgerBattler.Create
{
    //���j���[�\�̃g�b�s���O�̃R���g���[���[�N���X
    public class MenuToggleGroupController : MonoBehaviour
    {
        List<Toggle> togglesList = new List<Toggle>();
        [SerializeField] BurgerTogglesGroupController burgerTogglesGroupController;
        [SerializeField] TextMeshProUGUI explainText;
        [SerializeField] Image toppingImage;
        ToppingModel model;

        //�q��Toggle��onValueChanged��Change��ǉ����AToggleGroup��ݒ�
        public void SetToggleGroup()
        {
            var toggles = this.gameObject.GetComponentsInChildren<Transform>();
            foreach (var toggle in toggles)
            {
                if (toggle.GetComponent<Toggle>() != null)
                {
                    togglesList.Add(toggle.GetComponent<Toggle>()); 
                    toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change); //Change()��ǉ�
                    toggle.GetComponent<Toggle>().group = GetComponent<ToggleGroup>(); //toggle��group������object�ɐݒ�
                }
            }
        }

        //�N���b�N����Topping��model�ɑ��
        public void Change(bool state)
        {
            if (state)
            {
                foreach (var toggle in togglesList)
                {
                    //�I������Ă�toggle��������
                    if (toggle.isOn)
                    {
                        model = toggle.GetComponent<ToppingController>().model; 

                        burgerTogglesGroupController.SetPlayerTopping(model); //�I�񂾃g�b�s���O���o�[�K�[�ɃZ�b�g
                        explainText.SetText(model.explainText); //��������\��
                        toppingImage.sprite = model.icon;       //�A�C�R����\��
                    }
                }
            }
        }
    }
}
