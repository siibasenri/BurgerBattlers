using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    public class CardMove : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Transform defaltParent;
        public int childIndex;
        public Vector3 pos;
        public Quaternion rot;
        private AudioSource audioSource;

        private void Start()
        {
            defaltParent = transform.parent;
            audioSource = GetComponent<AudioSource>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(defaltParent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.SetAsLastSibling();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.SetParent(defaltParent);

        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            RectTransform rect = GetComponent<RectTransform>();
            //int popupHigh = 50;
            transform.rotation = Quaternion.Euler(Vector3.zero);
            //transform.position = new Vector3(transform.position.x, transform.parent.position.y + popupHigh, 0);
            //rect.position = new Vector2(rect.position.x, transform.parent.GetComponent<RectTransform>().position.y + rect.rect.height * 0.1f);
            rect.DOMove(new Vector2(rect.position.x, transform.parent.GetComponent<RectTransform>().position.y + rect.rect.height * 0.1f), 0.1f);
            transform.SetAsLastSibling();
            audioSource.Play();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.rotation = rot;
            //GetComponent<RectTransform>().position = pos;
            GetComponent<RectTransform>().DOMove(pos, 0.1f);
            //transform.position = pos;
            transform.SetSiblingIndex(childIndex);
        }
    }
}
