using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;

namespace BurgerBattler.Battle
{
    //コール用のパネルを閉じるボタンのクラス
    public class BackButtonController : MonoBehaviour
    {
        [SerializeField] FrontPanelController frontPanel;

    public void OnClick()
        {
            frontPanel.UpPanel(); //パネルを画面外の上にあげる
        }
    }
}
