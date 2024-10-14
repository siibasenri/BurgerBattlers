using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Topping
{
    [CreateAssetMenu(fileName = "ToppingEntity", menuName = "Create ToppingEntity")]

    //トッピングの情報を登録するためのクラス(WebGLでは不可)
    public class ToppingEntity :ScriptableObject
    {
        public int IDNumber;
        public string nameText;
        public Sprite iconSprite;
        public string explainText;
        public ToppingKind toppingKind;
    }

}
