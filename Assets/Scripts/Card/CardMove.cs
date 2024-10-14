using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //カードの動きに関するスクリプト
    public class CardMove : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Transform defaltParent;   //親
        public int childIndex;           //カードのインデックス(順番)
        public Vector3 pos;              //カードの位置
        public Quaternion rot;           //カードの角度
        private AudioSource audioSource; //効果音

        private void Start()
        {
            defaltParent = transform.parent;
            audioSource = GetComponent<AudioSource>();
        }

        //カードをドラッグしたとき
        public void OnBeginDrag(PointerEventData eventData)
        {
            transform.SetParent(defaltParent.parent);
            GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        //カードをドラッグしてるとき
        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position; //カーソルの位置にカードを持っていく
            transform.rotation = Quaternion.Euler(Vector3.zero);
            transform.SetAsLastSibling();
        }

        //カードのドラッグが終わったとき
        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            transform.SetParent(defaltParent);

        }

        //カードにカーソルがあったとき
        public void OnPointerEnter(PointerEventData eventData)
        {
            RectTransform rect = GetComponent<RectTransform>();
            transform.rotation = Quaternion.Euler(Vector3.zero);
            Vector2 popupPos = new Vector2(rect.position.x, rect.position.y + rect.rect.height * 0.1f); //カード全体が見える高さに移動
            rect.DOMove(popupPos, 0.1f);
            transform.SetAsLastSibling(); //カード達の中で一番手前に表示させる
            audioSource.Play();
        }

        //カードからカーソルが外れたとき
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.rotation = rot;
            GetComponent<RectTransform>().DOMove(pos, 0.1f);
            transform.SetSiblingIndex(childIndex);
        }
    }
}
