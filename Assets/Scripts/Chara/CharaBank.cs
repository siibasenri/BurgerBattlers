using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Chara
{
    public class CharaBank : MonoBehaviour
    {
        public CharaDetail[] charaDetails;
        private void Start()
        {
            charaDetails = GetComponentsInChildren<CharaDetail>();
        }
    }
}
