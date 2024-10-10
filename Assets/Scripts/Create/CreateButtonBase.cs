using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;

namespace BurgerBattler.Create
{
    public abstract class CreateButtonBase : MonoBehaviour
    {
        public abstract void BurgerCreate(ToppingModel[] Topping);
    }
}
