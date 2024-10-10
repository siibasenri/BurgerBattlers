using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

namespace BurgerBattler.Battle
{
    public class TurnTextController : MonoBehaviour
    {
        [SerializeField] GameObject goal;
        TextMeshProUGUI turnText;
        Vector3 startPos, endPos;
        float movespace;

        private void Start()
        {
            turnText = GetComponent<TextMeshProUGUI>();

            //startPos = GetComponent<RectTransform>().position;
            startPos = transform.position;
            movespace = (transform.parent.GetComponent<RectTransform>().position.x);
                //- GetComponent<RectTransform>().position.x) * 0.5f;
            //transform.parent.position.x - transform.position.x;
            //endPos = ;
        }
        public IEnumerator ShowText(string text, float waitTime)
        {
            turnText.SetText(text);
            //yield return new WaitForSeconds(waitTime);
            transform.DOMove(transform.parent.transform.position, waitTime*0.5f).SetEase(Ease.OutCirc);
            //GetComponent<RectTransform>().DOMoveX(movespace, waitTime).SetEase(Ease.InOutExpo);
            yield return new WaitForSeconds(waitTime*0.5f);

            transform.DOMove(goal.transform.position, waitTime*0.5f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(waitTime*0.5f);

            //transform.DOMoveX(movespace, waitTime).SetEase(Ease.InExpo);
            //yield return new WaitForSeconds(waitTime);

            //GetComponent<RectTransform>().DOMoveX(movespace, waitTime).SetEase(Ease.OutExpo);
            //yield return new WaitForSeconds(waitTime);


            transform.position = startPos;
            gameObject.SetActive(false);
        }
    }
}
