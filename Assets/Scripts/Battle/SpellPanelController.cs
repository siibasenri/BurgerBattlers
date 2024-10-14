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
    //�J�[�h���o�����߂̏�̃N���X
    public class SpellPanelController : MonoBehaviour, IDropHandler
    {
        [SerializeField] RuleBook ruleBook;        //�Q�[���̃��[�����Ǘ����Ă���N���X
        [SerializeField] GameFlowManager gameFlow; //�Q�[���̗�����Ǘ����Ă���N���X

        //�J�[�h���u���ꂽ��A�J�[�h�̌��ʂ𔭓�����
        public void OnDrop(PointerEventData eventData)
        {
            CardController dropCard = eventData.pointerDrag.GetComponent<CardController>();

            //�J�[�h���u����ĂāA�v���C���[�̃^�[���������ꍇ
            if (dropCard != null && gameFlow.GetState == GameState.PlayerTurn)
            {
                dropCard.GetComponent<CardMove>().enabled = false; //�J�[�h�̓����𖳌���
                dropCard.transform.DOMove(transform.position,0.3f); //�J�[�h�����₷���ʒu�Ɉړ�
                dropCard.transform.SetParent(this.transform);      //�J�[�h�̐e��SpellPanel�ɕύX

                StartCoroutine(ruleBook.UseCard(dropCard.model.kind)); //���ʂ𔭓�

                StartCoroutine(DestroyCard(dropCard.gameObject));      //�J�[�h��j��
            }
        }

        //�����I������J�[�h��j�󂷂�
        IEnumerator DestroyCard(GameObject card)
        {
            yield return new WaitForSeconds(2);
            Destroy(card);
        }
    }
}
