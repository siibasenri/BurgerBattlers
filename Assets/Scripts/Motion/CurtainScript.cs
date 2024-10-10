using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    public class CurtainScript : MonoBehaviour
    {
        public void OpenCurtain()
        {
            GetComponent<Image>().DOFade(0, 1f);
        }

        public void CloseCurtain()
        {
            GetComponent<Image>().DOFade(1, 1f);
        }
    }
}