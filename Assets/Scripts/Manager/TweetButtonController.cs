using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    public class TweetButtonController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] RuleBook ruleBook;
        public void OnClick()
        {
            if (ruleBook.isPlayerTurn)
            {
                StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot(
                    ruleBook.playerTurnCount+ "ターンで勝利！" +
                    "推理×カードゲーム×ハンバーガー！「バーガーバトラー」を遊んだよ！\n"+ 
                    "https://unityroom.com/games/burgerbattler"));
                //naichilab.UnityRoomTweet.Tweet("burgerbattler", ruleBook.turnCount+ "ターンで勝利！\n" +"推理×カードゲーム×ハンバーガー！「バーガーバトラー」を遊んだよ！\n", "BurgerBattel");
            }
            else
            {
                StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot(
                    ruleBook.enemyTurnCount + "ターンで敗北…\n" +
                    "推理×カードゲーム×ハンバーガー！「バーガーバトラー」を遊んだよ！\n" 
                    + "https://unityroom.com/games/burgerbattler"));
                //naichilab.UnityRoomTweet.Tweet("burgerbattler", ruleBook.turnCount+"ターンで敗北…\n" +"推理×カードゲーム×ハンバーガー！「バーガーバトラー」を遊んだよ！\n", "BurgerBattel");
            }
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
        }

    }
}
