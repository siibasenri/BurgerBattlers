using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Manager
{
    public class ResultPanelController : MonoBehaviour
    {
        [SerializeField] RuleBook ruleBook;
        [SerializeField] Image board;
        [SerializeField] Sprite winSrite, loseSprite;
        [SerializeField] TextMeshProUGUI turnText;

        public void showResult()
        {
            if (ruleBook.isPlayerTurn)
            {
                board.sprite = winSrite;
                turnText.SetText(ruleBook.playerTurnCount + "ターンで勝利！");
            }
            else
            {
                board.sprite = loseSprite;
                turnText.SetText(ruleBook.enemyTurnCount + "ターンで敗北…");
            }
        }
    }
}
