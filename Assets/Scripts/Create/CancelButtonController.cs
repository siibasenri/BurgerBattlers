using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    //作成したバーガーをキャンセルするボタンのクラス
    public class CancelButtonController : MonoBehaviour
    {
        [SerializeField] BurgerCreateMotionController motion; //バーガーの動きを管理するクラス
        [SerializeField] GameObject createButton; //仮決定ボタンのクラス
        [SerializeField] TextMeshProUGUI guide; //説明文を表示するテキスト
        [SerializeField] string text; //説明文

        public void OnClick()
        {
            guide.SetText(text);
            motion.CreateMode(); //重なっていたバーガーを作成状態に戻す
            createButton.SetActive(false); //仮作成ボタンを非表示
            gameObject.SetActive(false); 
        }
    }
}
