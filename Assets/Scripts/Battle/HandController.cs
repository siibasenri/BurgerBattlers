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
        int handCount; //��D�̖���
        List<Transform> cards = new List<Transform>();

        private void Start()
        {
            handCount = 0;
        }

        private void Update()
        {
            //��D�̖������ς�������ɌĂяo��
            if (handCount != transform.childCount) 
            {
                SetCardCondition();
            }
        }

        //��D�̃J�[�h�̈ʒu��X����ݒ�
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

        //�J�[�h���m���ǂꂭ�炢����邩��ݒ�
        void CardSpanInHand()
        {
            if (cards.Count != 0)
            {
                float cardsSpan = cards[0].transform.localScale.x * 50; //�J�[�h���m�̊Ԋu�x����

                for (int i = 0; i < cards.Count; i++)
                {
                    Vector3 cardPos = new Vector3((cards.Count - 1) * -cardsSpan + 2 * cardsSpan * i, 0, 0);
                    cards[i].GetComponent<RectTransform>().position = GetComponent<RectTransform>().position + cardPos;
                }
            }
        }

        //�J�[�h���ǂꂮ�炢�X������ݒ�
        void CardRotInHand()
        {
            float cardsSpan = 5.0f; //�J�[�h�̌X���x����

            for (int i = 0; i < cards.Count; i++)
            {
                cards[i].transform.rotation = Quaternion.Euler(0, 0, (cards.Count - 1) * cardsSpan - 2 * cardsSpan * i);
                cards[i].GetComponent<CardMove>().rot = cards[i].transform.rotation;
            }
        }
         
        //�J�[�h���ǂꂭ�炢�̍�������ݒ�
        void CardHighInHand()
        {
            float cardsSpan = 10.0f; //�J�[�h�̍����x����

            for (int i = 0; i < cards.Count; i++)
            {
                Vector3 cardPos = new Vector3(0, -1 * Mathf.Abs((cards.Count - 1) * -cardsSpan + 2 * cardsSpan * i), 0);
                cards[i].transform.position += cardPos;
                cards[i].GetComponent<CardMove>().pos = cards[i].GetComponent<RectTransform>().position;
            }
        }

        //�J�[�h���u���ꂽ��A�J�[�h���q�I�u�W�F�N�g�ɂ���
        public void OnDrop(PointerEventData eventData)
        {
            CardController dropCard = eventData.pointerDrag.GetComponent<CardController>();

            dropCard.transform.SetParent(this.transform);

        }
    }
}
