using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace BurgerBattler.Card
{
    //�J�[�h�̌����ڂɊւ���N���X
    public class CardView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText,explainText;
        [SerializeField] Image iconImage, revImage;
        private bool rev;

        public void Show(CardModel cardModel,bool isPlayer) // cardModel�̃f�[�^�擾�Ɣ��f
        {
            if (isPlayer)
            {
                nameText.text = cardModel.name;
                explainText.text = cardModel.explain;
                iconImage.sprite = cardModel.icon;
                revImage.enabled = false; //�J�[�h�̗��ʂ�Image���\��
                rev = false;
            }
            else
            {
                nameText.text = cardModel.name;
                explainText.text = cardModel.explain;
                iconImage.sprite = cardModel.icon;
                revImage.enabled = true; //�J�[�h�̗��ʂ�Image���\��
                transform.localScale = new Vector3(0.5f, 0.5f, 0);
                rev = true;
            }
        }
        public void Reverse()
        {
            rev = !rev;
            revImage.enabled = rev; 
        }
    }
}
