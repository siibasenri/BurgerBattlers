using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

namespace BurgerBattler.Battle
{
    //�^�[�����n�������Ƃ�\������e�L�X�g�̃N���X
    public class TurnTextController : MonoBehaviour
    {
        [SerializeField] GameObject goal; //�ړ���̃I�u�W�F�N�g
        TextMeshProUGUI turnText;         //�\������TextMexhPro
        Vector3 startPos;                 //�J�n�ʒu

        private void Start()
        {
            turnText = GetComponent<TextMeshProUGUI>();

            startPos = transform.position;
        }
        public IEnumerator ShowText(string text, float waitTime)
        {
            //������\��
            turnText.SetText(text);

            //�������ʒ����Ɉړ��A���X�Ɍ���
            transform.DOMove(transform.parent.transform.position, waitTime*0.5f).SetEase(Ease.OutCirc);
            yield return new WaitForSeconds(waitTime*0.5f);

            //��ʒ�������E�Ɉړ��A���X�ɉ���
            transform.DOMove(goal.transform.position, waitTime*0.5f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(waitTime*0.5f);

            //��ʍ��Ɉʒu��ύX��A��\��
            transform.position = startPos;
            gameObject.SetActive(false);
        }
    }
}
