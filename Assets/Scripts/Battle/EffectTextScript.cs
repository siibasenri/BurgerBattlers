using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BurgerBattler.Battle
{
    //吹き出しのセリフを書き換えるクラス
    public class EffectTextScript : MonoBehaviour
    {
        TextMeshProUGUI text;

        public IEnumerator ShowText(string message,float time)
        {
            text = GetComponentInChildren<TextMeshProUGUI>();

            //セリフを表示
            text.SetText(message);
            yield return new WaitForSeconds(time);

            //指定秒数後、セリフを無くし枠を非表示
            text.SetText("");
            gameObject.SetActive(false);
        }
    }
}
