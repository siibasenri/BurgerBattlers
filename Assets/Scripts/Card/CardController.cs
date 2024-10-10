using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;

namespace BurgerBattler.Card
{
    public class CardController : MonoBehaviour
    {
        public CardView view; // データを表示する
        public CardModel model; // データに関することを処理

        private void Awake()
        {
            view = GetComponent<CardView>();
        }

        public void Init(int cardID,bool isPlayer) // カードを生成した時に呼ばれる関数
        {
            model = new CardModel(cardID); //カードデータを生成
            view.Show(model,isPlayer);     //表示

            //対戦相手のカードだった場合
            if(!isPlayer)
            {
                this.GetComponent<CardMove>().enabled = false; //マウス移動やカーソル合わせた時の処理を無効化
            }
        }
    }
}
