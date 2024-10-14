using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //画面転換用の暗幕のクラス
    public class CurtainScript : MonoBehaviour
    {
        //画面を明るくする
        public void OpenCurtain()
        {
            GetComponent<Image>().DOFade(0, 1f);
        }

        //暗転する
        public void CloseCurtain()
        {
            GetComponent<Image>().DOFade(1, 1f);
        }
    }
}