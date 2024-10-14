using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Topping
{
    //トッピングの見た目を管理するクラス
    public class ToppingView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image icon;

        //渡されたmodelから、文字や画像を対応するものに変える
        public void Show(ToppingModel toppingModel)
        {
            nameText.text = toppingModel.nameText;
            icon.sprite = toppingModel.icon;
        }
    }
}
