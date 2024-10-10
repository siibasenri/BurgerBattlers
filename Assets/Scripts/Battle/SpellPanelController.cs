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
    public class SpellPanelController : MonoBehaviour, IDropHandler
    {
        [SerializeField] RuleBook ruleBook;
        [SerializeField] GameFlowManager gameFlow;

        //カードが置かれたら、カードの効果を発動する
        public void OnDrop(PointerEventData eventData)
        {
            CardController dropCard = eventData.pointerDrag.GetComponent<CardController>();

            if (dropCard != null && gameFlow.GetState == GameState.PlayerTurn)
            {
                dropCard.GetComponent<CardMove>().enabled = false;
                dropCard.transform.DOMove(transform.position,0.3f);
                dropCard.transform.SetParent(this.transform);

                StartCoroutine(ruleBook.UseCard(dropCard.model.kind));

                StartCoroutine(DestroyCard(dropCard.gameObject));
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
