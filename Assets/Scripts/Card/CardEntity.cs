using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card
{
    //�J�[�h�̏���o�^���邽�߂̃N���X(WebGL�ł͎g�p�s�\)
    [CreateAssetMenu(fileName = "CardEntity", menuName = "Create CardEntity")]

    public class CardEntity : ScriptableObject
    {
        public string nameText, explainText;
        public Sprite iconSprite, backSprite, revSprite;
        public CardKind kind;
    }
}

