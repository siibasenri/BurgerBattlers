using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using BurgerBattler.Card;
using BurgerBattler.Manager;
using BurgerBattler.Motion;
using DG.Tweening;

namespace BurgerBattler.Battle
{
    //カードを出すための場のクラス
    public class SpellPanelController : MonoBehaviour, IDropHandler
    {
        [SerializeField] RuleBook ruleBook;        //ゲームのルールを管理しているクラス
        [SerializeField] GameFlowManager gameFlow; //ゲームの流れを管理しているクラス

        //カードが置かれたら、カードの効果を発動する
        public void OnDrop(PointerEventData eventData)
        {
            CardController dropCard = eventData.pointerDrag.GetComponent<CardController>();

            //カードが置かれてて、プレイヤーのターンだった場合
            if (dropCard != null && gameFlow.GetState == GameState.PlayerTurn)
            {
                dropCard.GetComponent<CardMove>().enabled = false; //カードの動きを無効化
                dropCard.transform.DOMove(transform.position,0.3f); //カードを見やすい位置に移動
                dropCard.transform.SetParent(this.transform);      //カードの親をSpellPanelに変更

                StartCoroutine(ruleBook.UseCard(dropCard.model.kind)); //効果を発動

                StartCoroutine(DestroyCard(dropCard.gameObject));      //カードを破壊
            }
        }

        //唱え終わったカードを破壊する
        IEnumerator DestroyCard(GameObject card)
        {
            yield return new WaitForSeconds(2);
            Destroy(card);
        }
    }
}
