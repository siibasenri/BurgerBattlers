using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    public class CoverMotionScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] GameObject dish,burger,cover;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
           cover.GetComponent<RectTransform>().DOMove(burger.transform.position, 0.1f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
           cover.GetComponent<RectTransform>().DOMove(dish.transform.position, 0.1f);
        }
    }
}
