using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //対戦時自分のバーガーを確認するときのカバーの動きを管理するクラス
    public class CoverMotionScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] GameObject dish,burger,cover; //バーガーをのせてる皿、作成したバーガー、カバー
        
        //カーソルが合ったらカバーを上げる
        public void OnPointerEnter(PointerEventData eventData)
        {
           cover.GetComponent<RectTransform>().DOMove(burger.transform.position, 0.1f);
        }

        //カーソルが外れたら下げる
        public void OnPointerExit(PointerEventData eventData)
        {
           cover.GetComponent<RectTransform>().DOMove(dish.transform.position, 0.1f);
        }
    }
}
