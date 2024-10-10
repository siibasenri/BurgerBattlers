using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using BurgerBattler.Topping;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    public class CallPanelController : MonoBehaviour
    {
        [SerializeField] RuleBook ruleBook;
        [SerializeField] GameObject createPanel;
        [SerializeField] BurgerCreateMotionController motion;

        public void ClosePanel(ToppingModel[] toppings)
        {
            if (ruleBook.isPlayerTurn)
            {
                StartCoroutine(ruleBook.Call(toppings));
                createPanel.SetActive(false);
            }
        }
    }
}
