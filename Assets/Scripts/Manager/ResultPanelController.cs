using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Manager
{
    //リザルト画面を管理するクラス
    public class ResultPanelController : MonoBehaviour
    {
        [SerializeField] RuleBook ruleBook; 
        [SerializeField] Image board; //勝敗を表示する画像
        [SerializeField] Sprite winSrite, loseSprite; //勝利用画像、敗北用画像
        [SerializeField] TextMeshProUGUI turnText; //何ターンで勝ったかを表示するテキスト

        public void showResult()
        {
            //プレイヤーターンで勝敗が決まったなら勝ち
            if (ruleBook.isPlayerTurn)
            {
                board.sprite = winSrite;
                turnText.SetText(ruleBook.playerTurnCount + "ターンで勝利！");
            }
            //そうでないなら負け
            else
            {
                board.sprite = loseSprite;
                turnText.SetText(ruleBook.enemyTurnCount + "ターンで敗北…");
            }
        }
    }
}
