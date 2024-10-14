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
    //�Q�[���}�l�[�W���[
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
                "�r��̃E�G�X�^���̂ǂ����ɂ������c\n"+
                "���ɃM�����u����������Ă��Ȃ����̒n��ł́A�Ƃ���ς�����q�����������ɍs���Ă����B\n\n"+
                "�����̐H���Ɍ������������̎��A��l�̋q�̊Ԃł�\n" +
                "<color=yellow>�u�ǂ��炪��ɑ��肪�������������𓖂Ă��邩�v</color>����������" +
                "�Ƃ����A�Ɠ��̃M�����u�����B\n" +
                "���̃M�����u���́u�o�[�K�[�o�g���v�ƌĂ΂�A\n" +
                "�����́u�o�[�K�[�o�g���[�v�𐶂ނ��ƂƂȂ����c";

            yield return StartCoroutine(prologue.TalkText(content));
            yield return new WaitUntil(() => prologue.isClose);

            curtainScript.OpenCurtain(); //��ʂ����X�ɖ��邭
            BGMManager.PlayLobbyBGM();       //���r�[�p��BGM�𗬂�

            panelManager.ActiveCharaPanel(); //�L�����I��panel��Active��
            enemy.RandomCharaSelect();       //�G�̃L�����������_���ɐݒ�

            yield return new WaitForSeconds(1f);

            curtain.SetActive(false);
            charaSpawn.AllCharaCreate();     //�L�����𐶐�
            charaToggleGroupContorller.SetToggleGroup(); //charaToggle�̏�����
            charaSelectFrontPanel.DropPanel();

        }

        public void BurgerStageInit()
        {
            panelManager.ActiveBurgerPanel();  //�o�[�K�[�쐬panel��Active��
            toppingSpawn.AllToppingCreate();   //�g�b�s���O�𐶐�
            menuToggleGroupController.SetToggleGroup();  //menu��Toggle��������
            enemy.RandomAllToppingSelect();    //�G�̃g�b�s���O�������_���ɐݒ�
            burgerCreateFrontPanel.DropPanel();   
        }

        public IEnumerator BattleStageInit()
        {
            BGMManager.FadeOut();
            yield return new WaitForSeconds(1);
            panelManager.ActiveBattlePanel(); //�o�g��panel��Active��

            ruleBook.SetInfo(enemyInfo.burger, enemyInfo.hand, true);
            ruleBook.SetInfo(playerInfo.burger, playerInfo.hand, false);

            swingDoor.SetActive(true);    //�X�E�B���O�h�A��\��
            curtainScript.OpenCurtain(); //��ʂ����X�ɖ��邭

            yield return new WaitForSeconds(1);
            swingDoorScript.OpenDoor();  //�X�E�B���O�h�A���J����
            BGMManager.PlayBattleBGM();       //�o�g���p��BGM�𗬂�
            StartCoroutine(itemDropScript.DropItem()); //�A�C�e���𗎂Ƃ�

            yield return new WaitForSeconds(1.5f);
            curtain.SetActive(false);    //�J�[�e�����\��
            swingDoor.SetActive(false);  //�X�E�B���O�h�A���\��

            yield return new WaitForSeconds(1);
            gameFlow.NextStage();
        }

        public void DrawStageInit()
        {
            StartCoroutine(cardSpawns[0].AllCardCreate());   //�J�[�h�𐶐�(player)
            StartCoroutine(cardSpawns[1].AllCardCreate());   //�J�[�h�𐶐�(enemy)
            gameFlow.NextStage();
        }


        public IEnumerator PlayerTurnStageInit()
        {
            ruleBook.BattleInit();  //�o�g���̏�����
            turnText.gameObject.SetActive(true);
            yield return StartCoroutine(turnText.ShowText("Your Turn", 2f));
        }
        public void PlayerCheckStageInit()
        {

        }
        public IEnumerator EnemyTurnStageInit()
        {
            ruleBook.BattleInit();  //�o�g���̏�����
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
