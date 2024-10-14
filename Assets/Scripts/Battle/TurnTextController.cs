using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

namespace BurgerBattler.Battle
{
    //ターンが渡ったことを表示するテキストのクラス
    public class TurnTextController : MonoBehaviour
    {
        [SerializeField] GameObject goal; //移動先のオブジェクト
        TextMeshProUGUI turnText;         //表示するTextMexhPro
        Vector3 startPos;                 //開始位置

        private void Start()
        {
            turnText = GetComponent<TextMeshProUGUI>();

            startPos = transform.position;
        }
        public IEnumerator ShowText(string text, float waitTime)
        {
            //文字を表示
            turnText.SetText(text);

            //左から画面中央に移動、徐々に減速
            transform.DOMove(transform.parent.transform.position, waitTime*0.5f).SetEase(Ease.OutCirc);
            yield return new WaitForSeconds(waitTime*0.5f);

            //画面中央から右に移動、徐々に加速
            transform.DOMove(goal.transform.position, waitTime*0.5f).SetEase(Ease.InExpo);
            yield return new WaitForSeconds(waitTime*0.5f);

            //画面左に位置を変更後、非表示
            transform.position = startPos;
            gameObject.SetActive(false);
        }
    }
}
