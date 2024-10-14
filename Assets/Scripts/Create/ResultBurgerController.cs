using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;
using UnityEngine.UI;

namespace BurgerBattler.Create
{
    //�쐬�����o�[�K�[���m�F���邽�߂̃N���X
    public class ResultBurgerController : MonoBehaviour
    {
        [SerializeField] PlayerInfo player; //�v���C���[�̏��
        [SerializeField] Image[] toppings;  //�g�b�s���O��\�����邽�߂̉摜

        //�I�������g�b�s���O�̃C���X�g��ݒ�
        private void Update()
        {
            for(int i = 0;i<toppings.Length; i++)
            {
                toppings[i].sprite = player.burger[i].icon;
            }
        }
    }
}
