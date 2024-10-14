using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace BurgerBattler.Battle
{
    //�����o���̃Z���t������������N���X
    public class EffectTextScript : MonoBehaviour
    {
        TextMeshProUGUI text;

        public IEnumerator ShowText(string message,float time)
        {
            text = GetComponentInChildren<TextMeshProUGUI>();

            //�Z���t��\��
            text.SetText(message);
            yield return new WaitForSeconds(time);

            //�w��b����A�Z���t�𖳂����g���\��
            text.SetText("");
            gameObject.SetActive(false);
        }
    }
}
