using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;

namespace BurgerBattler.Create
{
    //�쐬�����o�[�K�[�����肷��{�^���̃x�[�X�N���X
    public abstract class CreateButtonBase : MonoBehaviour
    {
        public abstract void BurgerCreate(ToppingModel[] Topping);
    }
}
