using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;

namespace BurgerBattler.Battle
{
    //�R�[���p�̃p�l�������{�^���̃N���X
    public class BackButtonController : MonoBehaviour
    {
        [SerializeField] FrontPanelController frontPanel;

    public void OnClick()
        {
            frontPanel.UpPanel(); //�p�l������ʊO�̏�ɂ�����
        }
    }
}
