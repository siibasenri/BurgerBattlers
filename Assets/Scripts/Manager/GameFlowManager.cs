using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using BurgerBattler.Chara;
using BurgerBattler.Battle;
using UnityEngine.UI;


namespace BurgerBattler.Manager
{
    //ゲームの進行を管理するクラス
    public class GameFlowManager : MonoBehaviour
    {
        GameState gameState;
        GameManager instance;

        public bool isWin;

        public GameState GetState
        {
            get { return gameState; }
        }

        private void Start()
        {
            gameState = GameState.CharaSelect;
            instance = GameManager.GetInstance;
            isWin = false;
            StartCoroutine(GameManager.GetInstance.CharaStageInit());
        }

        public void NextStage()
        {
            gameState = NextStateFlow();

            switch(gameState)
            {
                case GameState.BurgerCreate:
                    instance.BurgerStageInit();
                    break;

                case GameState.BattleStart:
                    StartCoroutine(instance.BattleStageInit());
                    break;

                case GameState.Draw:
                    instance.DrawStageInit();
                    break;

                case GameState.PlayerTurn:
                    StartCoroutine(instance.PlayerTurnStageInit());
                    break;

                case GameState.PlayerCheck:
                    instance.PlayerCheckStageInit();
                    break;

                case GameState.EnemyTurn:
                    StartCoroutine(instance.EnemyTurnStageInit());
                    break;

                case GameState.EnemyCheck:
                    instance.EnemyCheckStageInit();
                    break;

                case GameState.Result:
                    instance.ResultStageInit();
                    break;
            }
        }

        //次のStateに移行する関数
        GameState NextStateFlow()
        {
            int currPhaseIndex = 0;                //現在のゲーム進捗を表すIndex
            GameState next = GameState.Draw;       //GameStateを初期化
            List<GameState> gameStateList = Enum.GetValues(typeof(GameState)) 
                .Cast<GameState>().ToList();       //EnumのGameStateをList化

            //現在の進捗のIndexを取得
            for (int i = 0; i < gameStateList.Count; i++)
            {
                if (gameStateList[i] == gameState)
                {
                    currPhaseIndex = i;
                }
            }

            if(gameState == GameState.Draw)
            {
                int coin = UnityEngine.Random.Range(0, 2);

                if (coin == 0) next = GameState.EnemyTurn;
                else next = GameState.PlayerTurn;

            }

            //どちらかが勝っていた場合
            else if ((gameState == GameState.PlayerCheck || gameState == GameState.EnemyCheck) && isWin )
            { 
                    next = GameState.Result;
            }

            //EnemyCheckで、Enemyが勝っていなかった場合
            else if (gameState == GameState.EnemyCheck && !isWin)
            {
                next = GameState.PlayerTurn;
            }

            //GameState順に次のステージに移行
            else
            {
                next = gameStateList[(currPhaseIndex + 1) % gameStateList.Count];
            }

            return next;
        }

    }
}
