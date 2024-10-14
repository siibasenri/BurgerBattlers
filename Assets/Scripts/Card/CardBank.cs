using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card
{
    //全カードの情報を一つにまとめるクラス
    public class CardBank : MonoBehaviour
    {
        public CardDetail[] cardDetails;

        private void Start()
        {
            cardDetails = GetComponentsInChildren<CardDetail>();
        }
    }
}
