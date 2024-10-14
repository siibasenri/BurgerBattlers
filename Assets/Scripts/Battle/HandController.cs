using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using BurgerBattler.Card;
using BurgerBattler.Motion;

namespace BurgerBattler.Battle
{
    public class HandController : MonoBehaviour,IDropHandler
    {
        int handCount; //手札の枚数
        List<Transform> cards = new List<Transform>();

        private void Start()
        {
            handCount = 0;
        }

        private void Update()
        {
            //手札の枚数が変わった時に呼び出す
            if (handCount != transform.childCount) 
            {
                SetCardCondition();
            }
        }

        //手札のカードの位置や傾きを設定
        void SetCardCondition()
        {
            cards.Clear();
            handCount = transform.childCount;
            Transform children = this.gameObject.GetComponentInChildren<Transform>();

            foreach (Transform card in children)
            {
                CardMove cardMove = card.GetComponent<CardMove>();
                cards.Add(card);
                cardMove.childIndex = card.GetSiblingIndex();
            }

            CardSpanInHand();
            CardRotInHand();
            CardHighInHand();
        }

        //カード同士がどれくらい離れるかを設定
        void CardSpanInHand()
        {
            if (cards.Count != 0)
            {
                float cardsSpan = cards[0].transform.localScale.x * 50; //カード同士の間隔度合い

                for (int i = 0; i < cards.Count; i++)
                {
                    Vector3 cardPos = new Vector3((cards.Count - 1) * -cardsSpan + 2 * cardsSpan * i, 0, 0);
                    cards[i].GetComponent<RectTransform>().position = GetComponent<RectTransform>().position + cardPos;
                }
            }
        }

        //カードがどれぐらい傾くかを設定
        void CardRotInHand()
        {
            float cardsSpan = 5.0f; //カードの傾き度合い

            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].transform.rotation = Quaternion.Euler(0, 0, (cards.Count - 1) * cardsSpan - 2 * cardsSpan * i);
                cards[i].GetComponent<CardMove>().rot = cards[i].transform.rotation;
            }
        }
         
        //カードがどれくらいの高さかを設定
        void CardHighInHand()
        {
            float cardsSpan = 10.0f; //カードの高さ度合い

            for (int i = 0; i < cards.Count; i++)
            {
                Vector3 cardPos = new Vector3(0, -1 * Mathf.Abs((cards.Count - 1) * -cardsSpan + 2 * cardsSpan * i), 0);
                cards[i].transform.position += cardPos;
                cards[i].GetComponent<CardMove>().pos = cards[i].GetComponent<RectTransform>().position;
            }
        }

        //カードが置かれたら、カードを子オブジェクトにする
        public void OnDrop(PointerEventData eventData)
        {
            CardController dropCard = eventData.pointerDrag.GetComponent<CardController>();

            dropCard.transform.SetParent(this.transform);

        }
    }
}
