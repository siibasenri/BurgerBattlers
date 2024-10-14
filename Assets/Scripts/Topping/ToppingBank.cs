using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Topping
{
    //全トッピングの情報をまとめておくクラス
    public class ToppingBank : MonoBehaviour
    {
        public ToppingDetail[] toppingDetails;
        private void Start()
        {
            toppingDetails = GetComponentsInChildren<ToppingDetail>();
        }
    }
}
