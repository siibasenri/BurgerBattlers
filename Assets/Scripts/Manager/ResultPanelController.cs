using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Manager
{
    //���U���g��ʂ��Ǘ�����N���X
    public class ResultPanelController : MonoBehaviour
    {
        [SerializeField] RuleBook ruleBook; 
        [SerializeField] Image board; //���s��\������摜
        [SerializeField] Sprite winSrite, loseSprite; //�����p�摜�A�s�k�p�摜
        [SerializeField] TextMeshProUGUI turnText; //���^�[���ŏ���������\������e�L�X�g

        public void showResult()
        {
            //�v���C���[�^�[���ŏ��s�����܂����Ȃ珟��
            if (ruleBook.isPlayerTurn)
            {
                board.sprite = winSrite;
                turnText.SetText(ruleBook.playerTurnCount + "�^�[���ŏ����I");
            }
            //�����łȂ��Ȃ畉��
            else
            {
                board.sprite = loseSprite;
                turnText.SetText(ruleBook.enemyTurnCount + "�^�[���Ŕs�k�c");
            }
        }
    }
}
