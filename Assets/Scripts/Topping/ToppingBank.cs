using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Topping
{
    public class ToppingBank : MonoBehaviour
    {
        public ToppingDetail[] toppingDetails;
        private void Start()
        {
            toppingDetails = GetComponentsInChildren<ToppingDetail>();
        }
    }
}
