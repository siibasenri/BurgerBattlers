using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;
using BurgerBattler.Manager;

namespace BurgerBattler.Chara
{
    //キャラクター選択を決定するボタンのクラス
    public class CharaSelectButton : MonoBehaviour
    {
        [SerializeField] GameFlowManager gameFlow; //ゲームの進行を管理するクラス
        [SerializeField] PlayerInfo player;        //プレイヤー情報
        [SerializeField] CharaToggleGroupContorller charaToggleGroupContorller; //キャラクター選択Toggle
        

        public void OnClick()
        {
            player.playerCharactor = charaToggleGroupContorller.model; //選択キャラをプレイヤーのキャラに決定
            gameFlow.NextStage(); //ゲームの進行を次に進める
        }
    }
}
