using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;

namespace BurgerBattler.Battle
{
    public class BackButtonController : MonoBehaviour
    {
        [SerializeField] FrontPanelController frontPanel;
        [SerializeField] BurgerCreateMotionController motion;
    public void OnClick()
        {
            frontPanel.UpPanel();
        }
    }
}
