using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;
using BurgerBattler.Manager;

namespace BurgerBattler.Chara
{
    //�L�����N�^�[�I�������肷��{�^���̃N���X
    public class CharaSelectButton : MonoBehaviour
    {
        [SerializeField] GameFlowManager gameFlow; //�Q�[���̐i�s���Ǘ�����N���X
        [SerializeField] PlayerInfo player;        //�v���C���[���
        [SerializeField] CharaToggleGroupContorller charaToggleGroupContorller; //�L�����N�^�[�I��Toggle
        

        public void OnClick()
        {
            player.playerCharactor = charaToggleGroupContorller.model; //�I���L�������v���C���[�̃L�����Ɍ���
            gameFlow.NextStage(); //�Q�[���̐i�s�����ɐi�߂�
        }
    }
}
