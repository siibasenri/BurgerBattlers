using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card
{
    //�S�J�[�h�̏�����ɂ܂Ƃ߂�N���X
    public class CardBank : MonoBehaviour
    {
        public CardDetail[] cardDetails;

        private void Start()
        {
            cardDetails = GetComponentsInChildren<CardDetail>();
        }
    }
}
