using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BurgerBattler.Battle
{
    public class EffectTextScript : MonoBehaviour
    {
        TextMeshProUGUI text;
        /*
        private void Awake()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
        */
        public IEnumerator ShowText(string message,float time)
        {
            text = GetComponentInChildren<TextMeshProUGUI>();

            text.SetText(message);
            yield return new WaitForSeconds(time);
            text.SetText("");
            gameObject.SetActive(false);
        }
    }
}
