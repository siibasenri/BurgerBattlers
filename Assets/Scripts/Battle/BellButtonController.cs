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
    //ハンバーガーをコールするベルを押したときのクラス
    public class BellButtonController : MonoBehaviour
    {
        [SerializeField] FrontPanelController frontPanel;　//バーガー作成
        [SerializeField] MenuToggleGroupController menuToggleGroupController; //作成したバーガーのトグル
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] AudioSource audioSource;
        [SerializeField] BurgerCreateMotionController motion; //バーガーの動き
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
                motion.InitMode(); //コールパネルを初期状態に設定
                audioSource.Play(); //SE再生
                frontPanel.DropPanel(); //作成パネルを上から下に落とす
            }
        }
    }
}
