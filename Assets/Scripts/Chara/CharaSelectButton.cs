using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;
using BurgerBattler.Manager;

namespace BurgerBattler.Chara
{
    public class CharaSelectButton : MonoBehaviour
    {
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] PlayerInfo player;
        [SerializeField] CharaToggleGroupContorller charaToggleGroupContorller;
        

        public void OnClick()
        {
            player.playerCharactor = charaToggleGroupContorller.model;
            gameFlow.NextStage();
        }
    }
}
