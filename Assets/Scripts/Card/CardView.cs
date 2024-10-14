using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace BurgerBattler.Card
{
    //カードの見た目に関するクラス
    public class CardView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText,explainText;
        [SerializeField] Image iconImage, revImage;
        private bool rev;

        public void Show(CardModel cardModel,bool isPlayer) // cardModelのデータ取得と反映
        {
            if (isPlayer)
            {
                nameText.text = cardModel.name;
                explainText.text = cardModel.explain;
                iconImage.sprite = cardModel.icon;
                revImage.enabled = false; //カードの裏面のImageを非表示
                rev = false;
            }
            else
            {
                nameText.text = cardModel.name;
                explainText.text = cardModel.explain;
                iconImage.sprite = cardModel.icon;
                revImage.enabled = true; //カードの裏面のImageを非表示
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
