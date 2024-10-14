using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //�J�[�h�̓����Ɋւ���X�N���v�g
    public class CardMove : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Transform defaltParent;   //�e
        public int childIndex;           //�J�[�h�̃C���f�b�N�X(����)
        public Vector3 pos;              //�J�[�h�̈ʒu
        public Quaternion rot;           //�J�[�h�̊p�x
        private AudioSource audioSource; //���ʉ�

        private void Start()
        {
            defaltParent = transform.parent;
            audioSource = GetComponent<AudioSource>();
        }

        //�J�[�h���h���b�O�����Ƃ�
        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(defaltParent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        //�J�[�h���h���b�O���Ă�Ƃ�
        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position; //�J�[�\���̈ʒu�ɃJ�[�h�������Ă���
            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.SetAsLastSibling();
        }

        //�J�[�h�̃h���b�O���I������Ƃ�
        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.SetParent(defaltParent);

        }

        //�J�[�h�ɃJ�[�\�����������Ƃ�
        public void OnPointerEnter(PointerEventData eventData)
        {
            RectTransform rect = GetComponent<RectTransform>();
            transform.rotation = Quaternion.Euler(Vector3.zero);
            Vector2 popupPos = new Vector2(rect.position.x, rect.position.y + rect.rect.height * 0.1f); //�J�[�h�S�̂������鍂���Ɉړ�
            rect.DOMove(popupPos, 0.1f);
            transform.SetAsLastSibling(); //�J�[�h�B�̒��ň�Ԏ�O�ɕ\��������
            audioSource.Play();
        }

        //�J�[�h����J�[�\�����O�ꂽ�Ƃ�
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.rotation = rot;
            GetComponent<RectTransform>().DOMove(pos, 0.1f);
            transform.SetSiblingIndex(childIndex);
        }
    }
}
