using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card

    //カードのデータを管理するクラス
{    public class CardModel 
    {
        public string name, explain; //名前と説明文
        public Sprite icon, back, rev; //アイコンと背景と裏面
        public CardKind kind; //カード種類

        public bool isPlayersCard; //プレイヤーのカードか否か


        public CardModel(int cardID)
        {
            /*
            CardEntityから情報を参照する方法(WebGLでは不可)
            CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID); // CardEntityのパス
            */

            //bank内のcardDetailを参照する方法(WebGL用)
            GameObject bank = GameObject.Find("Bank");
            CardDetail cardDetail = bank.GetComponent<CardBank>().cardDetails[cardID];

            name = cardDetail.nameText;
            icon = cardDetail.iconSprite;
            explain = cardDetail.explainText;
            back = cardDetail.backSprite;
            rev = cardDetail.revSprite;
            kind = cardDetail.kind;
        }
    }
}
