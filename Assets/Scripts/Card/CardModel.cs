using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card
{    public class CardModel 
    {
        public string name, explain;
        public Sprite icon, back, rev;
        public CardKind kind;

        public bool isPlayersCard;

        public CardModel(int cardID) // データを受け取り、その処理
        {
            //CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID); // CardEntityのパス

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
