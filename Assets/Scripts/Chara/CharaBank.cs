using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Chara
{
    //�S�L�����N�^�[�̏�����ɂ܂Ƃ߂�N���X
    public class CharaBank : MonoBehaviour
    {
        public CharaDetail[] charaDetails;
        private void Start()
        {
            charaDetails = GetComponentsInChildren<CharaDetail>();
        }
    }
}
