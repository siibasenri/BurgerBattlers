using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Topping
{
    //�S�g�b�s���O�̏����܂Ƃ߂Ă����N���X
    public class ToppingBank : MonoBehaviour
    {
        public ToppingDetail[] toppingDetails;
        private void Start()
        {
            toppingDetails = GetComponentsInChildren<ToppingDetail>();
        }
    }
}
