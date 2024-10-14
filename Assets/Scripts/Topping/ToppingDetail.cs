using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Topping
{
    //トッピングの情報を登録するためのクラス(WebGL用)
    public class ToppingDetail : MonoBehaviour
    {
        public int IDNumber;
        public string nameText;
        public Sprite iconSprite;
        public string explainText;
        public ToppingKind toppingKind;
    }
}
