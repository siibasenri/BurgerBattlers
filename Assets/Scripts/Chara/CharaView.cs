using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Chara
{
    //キャラクターの見ためを管理するクラス
    public class CharaView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText, explainText;
        [SerializeField] Image iconImage;
        
        //テキストや画像を表示する
        public void Show(CharaModel charaModel)
        {
            nameText.text = charaModel.name;
            iconImage.sprite = charaModel.icon;
            explainText.text = charaModel.explain;
        }
    }
}
