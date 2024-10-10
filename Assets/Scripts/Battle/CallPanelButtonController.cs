using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;
using BurgerBattler.Manager;
using BurgerBattler.Create;
using BurgerBattler.Motion;

namespace BurgerBattler.Battle
{
    public class CallPanelButtonController : MonoBehaviour
    {
        [SerializeField] GameObject callPanel;
        [SerializeField] MenuToggleGroupController menuToggleGroupController;
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] AudioSource auidoSource;
        [SerializeField] BurgerCreateMotionController motion;

        //コールを宣言したときにパネルを表示
        public void OnClick()
        {
            if (gameFlow.GetState == GameState.PlayerTurn)
            {
                auidoSource.Play();
                callPanel.SetActive(true);
                GetComponent<ToppingSpawn>().AllToppingCreate();
                menuToggleGroupController.SetToggleGroup();
            }
        }
    }
}
