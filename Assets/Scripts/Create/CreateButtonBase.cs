using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;

namespace BurgerBattler.Create
{
    //作成したバーガーを決定するボタンのベースクラス
    public abstract class CreateButtonBase : MonoBehaviour
    {
        public abstract void BurgerCreate(ToppingModel[] Topping);
    }
}
