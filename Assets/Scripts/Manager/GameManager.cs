using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using BurgerBattler.Card;
using BurgerBattler.Chara;
using BurgerBattler.Topping;
using BurgerBattler.Player;
using BurgerBattler.Battle;
using BurgerBattler.Motion;
using BurgerBattler.Create;
using DG.Tweening;


namespace BurgerBattler.Manager
{
    //ゲームマネージャー
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;

        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] CharaSpawn charaSpawn;
        [SerializeField] ToppingSpawn toppingSpawn;
        [SerializeField] GameObject spawner,curtain,swingDoor;
        [SerializeField] PanelManager panelManager;
        [SerializeField] EnemyController enemy;
        [SerializeField] PlayerInfo enemyInfo, playerInfo;
        [SerializeField] CharaToggleGroupContorller charaToggleGroupContorller;
        [SerializeField] MenuToggleGroupController menuToggleGroupController;
        [SerializeField] RuleBook ruleBook;
        [SerializeField] BGMManager BGMManager;
        [SerializeField] FrontPanelController charaSelectFrontPanel,burgerCreateFrontPanel;
        [SerializeField] ItemDropScript itemDropScript;
        [SerializeField] TalkManager prologue;
        [SerializeField] TurnTextController turnText;
        [SerializeField] ResultPanelController resultPanel;
        

        CardSpawn[] cardSpawns;
        CurtainScript curtainScript;
        SwingDoorScript swingDoorScript;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else Destroy(gameObject);
            curtainScript = curtain.GetComponent<CurtainScript>();
        }

        public static GameManager GetInstance
        {
            get { return instance; }
        }
        private void Start()
        {
            cardSpawns = spawner.GetComponents<CardSpawn>();
            swingDoorScript = swingDoor.GetComponent<SwingDoorScript>();
        }


        public IEnumerator CharaStageInit()
        {
            prologue.gameObject.SetActive(true);
            curtain.SetActive(true);
            string content = 
                "荒野のウエスタンのどこかにある酒場…\n"+
                "公にギャンブルが許可されていないこの地区では、とある変わった賭け事が密かに行われていた。\n\n"+
                "ただの食事に見せかけたその実、二人の客の間では\n" +
                "<color=yellow>「どちらが先に相手が注文した料理を当てられるか」</color>を勝負する" +
                "という、独特のギャンブルだ。\n" +
                "このギャンブルは「バーガーバトル」と呼ばれ、\n" +
                "多くの「バーガーバトラー」を生むこととなった…";

            yield return StartCoroutine(prologue.TalkText(content));
            yield return new WaitUntil(() => prologue.isClose);

            curtainScript.OpenCurtain(); //画面を徐々に明るく
            BGMManager.PlayLobbyBGM();       //ロビー用のBGMを流す

            panelManager.ActiveCharaPanel(); //キャラ選択panelをActiveに
            enemy.RandomCharaSelect();       //敵のキャラをランダムに設定

            yield return new WaitForSeconds(1f);

            curtain.SetActive(false);
            charaSpawn.AllCharaCreate();     //キャラを生成
            charaToggleGroupContorller.SetToggleGroup(); //charaToggleの初期化
            charaSelectFrontPanel.DropPanel();

        }

        public void BurgerStageInit()
        {
            panelManager.ActiveBurgerPanel();  //バーガー作成panelをActiveに
            toppingSpawn.AllToppingCreate();   //トッピングを生成
            menuToggleGroupController.SetToggleGroup();  //menuのToggleを初期化
            enemy.RandomAllToppingSelect();    //敵のトッピングをランダムに設定
            burgerCreateFrontPanel.DropPanel();   
        }

        public IEnumerator BattleStageInit()
        {
            BGMManager.FadeOut();
            yield return new WaitForSeconds(1);
            panelManager.ActiveBattlePanel(); //バトルpanelをActiveに

            ruleBook.SetInfo(enemyInfo.burger, enemyInfo.hand, true);
            ruleBook.SetInfo(playerInfo.burger, playerInfo.hand, false);

            swingDoor.SetActive(true);    //スウィングドアを表示
            curtainScript.OpenCurtain(); //画面を徐々に明るく

            yield return new WaitForSeconds(1);
            swingDoorScript.OpenDoor();  //スウィングドアを開ける
            BGMManager.PlayBattleBGM();       //バトル用のBGMを流す
            StartCoroutine(itemDropScript.DropItem()); //アイテムを落とす

            yield return new WaitForSeconds(1.5f);
            curtain.SetActive(false);    //カーテンを非表示
            swingDoor.SetActive(false);  //スウィングドアを非表示

            yield return new WaitForSeconds(1);
            gameFlow.NextStage();
        }

        public void DrawStageInit()
        {
            StartCoroutine(cardSpawns[0].AllCardCreate());   //カードを生成(player)
            StartCoroutine(cardSpawns[1].AllCardCreate());   //カードを生成(enemy)
            gameFlow.NextStage();
        }


        public IEnumerator PlayerTurnStageInit()
        {
            ruleBook.BattleInit();  //バトルの初期化
            turnText.gameObject.SetActive(true);
            yield return StartCoroutine(turnText.ShowText("Your Turn", 2f));
        }
        public void PlayerCheckStageInit()
        {

        }
        public IEnumerator EnemyTurnStageInit()
        {
            ruleBook.BattleInit();  //バトルの初期化
            turnText.gameObject.SetActive(true);
            yield return StartCoroutine(turnText.ShowText("Enemy Turn",2f));
            yield return StartCoroutine(enemy.RandomAction());
        }

        public void EnemyCheckStageInit()
        {
        }


        public void ResultStageInit()
        {
            panelManager.ActiveResultPanel();
            resultPanel.showResult();

        }

    }
}
