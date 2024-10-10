using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card
{
    [CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

    public class CardEntity : ScriptableObject
    {
        public string nameText, explainText;
        public Sprite iconSprite, backSprite, revSprite;
        public CardKind kind;
    }
}

