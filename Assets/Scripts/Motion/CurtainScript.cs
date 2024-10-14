using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //‰æ–Ê“]Š·—p‚ÌˆÃ–‹‚ÌƒNƒ‰ƒX
    public class CurtainScript : MonoBehaviour
    {
        //‰æ–Ê‚ð–¾‚é‚­‚·‚é
        public void OpenCurtain()
        {
            GetComponent<Image>().DOFade(0, 1f);
        }

        //ˆÃ“]‚·‚é
        public void CloseCurtain()
        {
            GetComponent<Image>().DOFade(1, 1f);
        }
    }
}