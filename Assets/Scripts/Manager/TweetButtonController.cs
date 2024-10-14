using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    //リザルト画面で、Xにポストするクラス
    public class TweetButtonController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] RuleBook ruleBook;
        public void OnClick()
        {
            //勝利用のツイート文
            if (ruleBook.isPlayerTurn)
            {
                StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot(
                    ruleBook.playerTurnCount+ "ターンで勝利！" +
                    "推理×カードゲーム×ハンバーガー！「バーガーバトラー」を遊んだよ！\n"+ 
                    "https://unityroom.com/games/burgerbattler"));
            }
            //敗北用のツイート文
            else
            {
                StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot(
                    ruleBook.enemyTurnCount + "ターンで敗北…\n" +
                    "推理×カードゲーム×ハンバーガー！「バーガーバトラー」を遊んだよ！\n" 
                    + "https://unityroom.com/games/burgerbattler"));
            }
        }
        //カーソルがあったとき大きくする
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
        }

        //カーソルが外れたとき小さくする
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
        }

    }
}
