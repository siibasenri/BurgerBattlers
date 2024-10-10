using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;
using BurgerBattler.Player;
using BurgerBattler.Topping;
using BurgerBattler.Manager;

namespace BurgerBattler.Create
{
    public class BurgerCreateButtonController : CreateButtonBase
    {
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] PlayerInfo player;
        [SerializeField] BurgerTogglesGroupController toggleGroup;
        [SerializeField] CurtainScript curtainScript;


        public void OnClick()
        {
            curtainScript.gameObject.SetActive(true);
            curtainScript.CloseCurtain();
            gameFlow.NextStage();
        }

        public override void BurgerCreate(ToppingModel[] Toppings)
        {
            player.top = Toppings[0];
            player.mid = Toppings[1];
            player.bot = Toppings[2];
            player.burger = Toppings;
        }
    }
}
