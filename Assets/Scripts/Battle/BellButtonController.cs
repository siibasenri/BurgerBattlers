using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;
using BurgerBattler.Topping;
using BurgerBattler.Manager;
using BurgerBattler.Create;
using TMPro;

namespace BurgerBattler.Battle
{
    public class BellButtonController : MonoBehaviour
    {
        [SerializeField] FrontPanelController frontPanel;
        [SerializeField] MenuToggleGroupController menuToggleGroupController;
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] AudioSource audioSource;
        [SerializeField] BurgerCreateMotionController motion;
        [SerializeField] TextMeshProUGUI guide;

        private void Start()
        {
            frontPanel.gameObject.SetActive(true);
            GetComponent<ToppingSpawn>().AllToppingCreate();
            menuToggleGroupController.SetToggleGroup();
        }

        public void OnClick()
        {
            if (gameFlow.GetState == GameState.PlayerTurn)
            {
                guide.SetText("予想したハンバーガーを作ってください");
                motion.InitMode();
                audioSource.Play();
                frontPanel.DropPanel();
            }
        }
    }
}
