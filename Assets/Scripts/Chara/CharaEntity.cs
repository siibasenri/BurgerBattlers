using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerBattler.Chara
{
    [CreateAssetMenu(fileName = "CharaEntity", menuName = "Create CharaEntity")]

    //キャラクターのデータを登録するためのクラス(WebGLでは使用不可)
    public class CharaEntity : ScriptableObject
    {
        //public int charaID;
        public CharaKind charaKind;
        public string charaName;
        public Sprite charaIcon;
        public string charaExplain;
    }
}
