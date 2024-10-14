using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;
using UnityEngine.UI;

namespace BurgerBattler.Create
{
    //作成したバーガーを確認するためのクラス
    public class ResultBurgerController : MonoBehaviour
    {
        [SerializeField] PlayerInfo player; //プレイヤーの情報
        [SerializeField] Image[] toppings;  //トッピングを表示するための画像

        //選択したトッピングのイラストを設定
        private void Update()
        {
            for(int i = 0;i<toppings.Length; i++)
            {
                toppings[i].sprite = player.burger[i].icon;
            }
        }
    }
}
