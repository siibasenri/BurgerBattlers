using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Chara
{
    //キャラクターのデータを登録するためのクラス(WebGL用)
    public class CharaDetail : MonoBehaviour
    {
        public CharaKind charaKind;
        public string charaName;
        public Sprite charaIcon;
        public string charaExplain;
    }
}
