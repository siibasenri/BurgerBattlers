using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Topping
{
    //�g�b�s���O�̌����ڂ��Ǘ�����N���X
    public class ToppingView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image icon;

        //�n���ꂽmodel����A������摜��Ή�������̂ɕς���
        public void Show(ToppingModel toppingModel)
        {
            nameText.text = toppingModel.nameText;
            icon.sprite = toppingModel.icon;
        }
    }
}
