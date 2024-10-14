using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card
{
    //カードの持つ情報に関するクラス(WebGL用)
    public class CardDetail : MonoBehaviour
    {
        public string nameText, explainText;
        public Sprite iconSprite, backSprite, revSprite;
        public CardKind kind;
    }
}