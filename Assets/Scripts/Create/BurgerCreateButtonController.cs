using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;
using BurgerBattler.Player;
using BurgerBattler.Topping;
using BurgerBattler.Manager;

namespace BurgerBattler.Create
{
    //作成したバーガーを確定するボタンのクラス
    public class BurgerCreateButtonController : CreateButtonBase
    {
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] PlayerInfo player;
        [SerializeField] BurgerTogglesGroupController toggleGroup;
        [SerializeField] CurtainScript curtainScript;

        //ボタンを押したら
        public void OnClick()
        {
            //画面を暗転
            curtainScript.gameObject.SetActive(true);
            curtainScript.CloseCurtain();

            //ゲームを次のステップに移行
            gameFlow.NextStage();
        }
        

        //プレイヤー情報にバーガーのトッピングを追加
        public override void BurgerCreate(ToppingModel[] Toppings)
        {
            player.top = Toppings[0];
            player.mid = Toppings[1];
            player.bot = Toppings[2];
            player.burger = Toppings;
        }
    }
}
