using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using BurgerBattler.Chara;
using BurgerBattler.Topping;

namespace BurgerBattler.Player
{
    //�v���C���[�̏����Ǘ�����N���X
    public class PlayerInfo : MonoBehaviour
    {
        public CharaModel playerCharactor; //�v���C���[�̃L����
        public ToppingModel top, mid, bot; //�v���C���[�̐��삵���o�[�K�[�̊e�g�b�s���O
        public ToppingModel[] burger;      //�g�b�s���O�̔z��
        public GameObject hand;            //��D
        public bool isPayer;               //�v���C���[���ۂ�

        //������
        private void Start()
        {
            playerCharactor = new CharaModel(0);

            top = new ToppingModel(0);
            mid = new ToppingModel(1);
            bot = new ToppingModel(2);
            
            burger = new ToppingModel[3];

            if (transform.name == "Player") isPayer = true;
            else if (transform.name == "Enemy") isPayer = false;
        }
    }
}
