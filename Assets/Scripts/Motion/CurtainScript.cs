using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //��ʓ]���p�̈Ö��̃N���X
    public class CurtainScript : MonoBehaviour
    {
        //��ʂ𖾂邭����
        public void OpenCurtain()
        {
            GetComponent<Image>().DOFade(0, 1f);
        }

        //�Ó]����
        public void CloseCurtain()
        {
            GetComponent<Image>().DOFade(1, 1f);
        }
    }
}