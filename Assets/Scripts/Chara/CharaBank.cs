using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Chara
{
    //全キャラクターの情報を一つにまとめるクラス
    public class CharaBank : MonoBehaviour
    {
        public CharaDetail[] charaDetails;
        private void Start()
        {
            charaDetails = GetComponentsInChildren<CharaDetail>();
        }
    }
}
