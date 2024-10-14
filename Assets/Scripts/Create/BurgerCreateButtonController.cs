using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;
using BurgerBattler.Player;
using BurgerBattler.Topping;
using BurgerBattler.Manager;

namespace BurgerBattler.Create
{
    //�쐬�����o�[�K�[���m�肷��{�^���̃N���X
    public class BurgerCreateButtonController : CreateButtonBase
    {
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] PlayerInfo player;
        [SerializeField] BurgerTogglesGroupController toggleGroup;
        [SerializeField] CurtainScript curtainScript;

        //�{�^������������
        public void OnClick()
        {
            //��ʂ��Ó]
            curtainScript.gameObject.SetActive(true);
            curtainScript.CloseCurtain();

            //�Q�[�������̃X�e�b�v�Ɉڍs
            gameFlow.NextStage();
        }
        

        //�v���C���[���Ƀo�[�K�[�̃g�b�s���O��ǉ�
        public override void BurgerCreate(ToppingModel[] Toppings)
        {
            player.top = Toppings[0];
            player.mid = Toppings[1];
            player.bot = Toppings[2];
            player.burger = Toppings;
        }
    }
}
