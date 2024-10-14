using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    //作成したバーガーを仮決定(キャンセル可)するボタンのクラス
    public class BurgerDecideButton : MonoBehaviour
    {
        [SerializeField] BurgerCreateMotionController motion;
        [SerializeField] GameObject createButton, cancelButton;
        [SerializeField] TextMeshProUGUI guide;
        

        public void OnClick()
        {
            motion.BurgerCompleteMode(); //バーガーを重ねる
            createButton.SetActive(true); //本決定するボタンを表示
            cancelButton.SetActive(true); //キャンセルボタンを表示
            this.gameObject.SetActive(false); //このボタンを非表示
            guide.SetText("これでよろしいですか？"); //説明テキストに確認文を表示
        }
    }
}
