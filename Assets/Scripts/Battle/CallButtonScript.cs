using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BurgerBattler.Topping;
using BurgerBattler.Motion;
using BurgerBattler.Create;

namespace BurgerBattler.Battle
{
    public class CallButtonScript : CreateButtonBase
    {
        [SerializeField] RuleBook ruleBook;
        [SerializeField] FrontPanelController frontPanel;
        [SerializeField] BurgerCreateMotionController motion;
        ToppingModel[] call;

        //�I�������o�[�K�[�̃g�b�s���O�����[���u�b�N�ɓn���āA��v���Ă��邩�𒲂ׂ�
        public void OnClick()
        {
            frontPanel.UpPanel();

            StartCoroutine(ruleBook.Call(call));
        }

        public override void BurgerCreate(ToppingModel[] Toppings)
        {
            call = Toppings;
        }
    }
}
