using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using BurgerBattler.Card;
using BurgerBattler.Player;
using BurgerBattler.Manager;
using BurgerBattler.Topping;
using BurgerBattler.Battle;
using UnityEngine.UI;

namespace BurgerBattler.Battle
{
    public class RuleBook : MonoBehaviour
    {
        [SerializeField] GameFlowManager gameFlow;       //�Q�[���̗���
        [SerializeField] GameObject enemySpeechFlame, playerSpeechFlame;//�G�̃Z���t�̐����o��
        [SerializeField] BattleLog enemyLog;

        public bool isPlayerTurn,isPlayMax;                        //�v���C���[�̃^�[����
        public int playerTurnCount,enemyTurnCount;

        GameObject oppHand,playerHand, enemyHand;        //�v���C���[�Ǝ����̎�D�����鏊
        ToppingModel[] oppToppings, myToppings, enemyToppings, playerToppings; //�������猩���A�G��topping���X�g
        EffectTextScript oppEffectTextScript,myEffectTextScript;               
        GameObject oppSpeechFlame,mySpeechFlame;

        int maxSpellCount,currSpellCount;                //��������J�[�h�̏���ƁA���ݏ������J�[�h��
        float speechTime;                               //�J�[�h�g�p��R�[���̉��o�ɂ����鎞��
        string resultText;                               //�����o���ɕ\������e�L�X�g



        private void Start()
        {
            isPlayerTurn = false;
            isPlayMax = false;

            maxSpellCount = 1;
            currSpellCount = 0;
            speechTime = 2f;
            playerTurnCount = 0;
            enemyTurnCount = 0;

            oppToppings = new ToppingModel[3];
            myToppings = new ToppingModel[3];
        }

        //�J�[�h��������ꂽ���̏���
        public IEnumerator UseCard(CardKind type)
        {
            gameFlow.NextStage();

            yield return StartCoroutine(CardAbility(type));
            currSpellCount++;
            
            if (maxSpellCount == currSpellCount)
            {
                isPlayMax = true;
                gameFlow.NextStage();
            }
        }

        //�J�[�h���̌��ʏ���
        IEnumerator CardAbility(CardKind type)
        {

            yield return new WaitForSeconds(1f);
            switch (type)
            {

                //�ΐ푊�肪Pow������Topping���g���Ă��邩
                case CardKind.isPow:

                    mySpeechFlame.SetActive(true);
                    resultText = "�x�[�R���ƃp�e�B�̐��́H";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    resultText = "�x�[�R���ƃp�e�B�͎g���ĂȂ��B";
                    int powCount = 0;
                    for (int i = 0; i < oppToppings.Length; i++)
                    {
                        if (oppToppings[i].toppingKind == ToppingKind.POW)
                        {
                            powCount++;
                        }
                    }
                    if (powCount != 0)
                    {
                        resultText = "�x�[�R���ƃp�e�B�����v" +
                            "<color=red>" + powCount.ToString() + "</color>" + "�g���Ă���B";
                    }
                    yield return new WaitForSeconds(speechTime);
                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);

                    WriteLog(type, powCount, "");
                    break;


                //�ΐ푊�肪Hea������Topping���g���Ă��邩
                case CardKind.isHea:
                    mySpeechFlame.SetActive(true);
                    resultText = "�g�}�g�ƃL���x�c�̐��́H";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    resultText = "�g�}�g�ƃL���x�c�͎g���ĂȂ��B";
                    int heaCount = 0;
                    for (int i = 0; i < oppToppings.Length; i++)
                    {
                        if (oppToppings[i].toppingKind == ToppingKind.HEA)
                        {
                            heaCount++;
                        }
                    }
                    if (heaCount != 0)
                    {
                        resultText = "�g�}�g�ƃL���x�c�����v" +
                            "<color=red>" + heaCount + "</color>" + "�g���Ă���B";
                    }
                    yield return new WaitForSeconds(speechTime);
                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);


                    WriteLog(type, heaCount, "");
                    break;


                //�ΐ푊�肪Nat������Topping���g���Ă��邩
                case CardKind.isNat:
                    mySpeechFlame.SetActive(true);
                    resultText = "�`�[�Y�Ƌʎq�̐��́H";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    int natCount = 0;
                    resultText = "�`�[�Y�Ƌʎq�͎g���ĂȂ��B";

                    for (int i = 0; i < oppToppings.Length; i++)
                    {
                        if (oppToppings[i].toppingKind == ToppingKind.NAT)
                        {
                            natCount++;
                        }
                    }

                    if (natCount != 0)
                    {
                        resultText = "�`�[�Y�Ƌʎq�����v" +
                            "<color=red>" + natCount + "</color>" + "�g���Ă���B";
                    }
                    yield return new WaitForSeconds(speechTime);
                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);


                    WriteLog(type, natCount, "");
                    break;


                //�ΐ푊�肪�g�p���Ă��Ȃ��g�b�s���O�������_���Ɉ�����Ă����B
                case CardKind.isNotIn:

                    mySpeechFlame.SetActive(true);
                    resultText = "�g���ĂȂ��g�b�s���O�́H";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    //#228b22���΁A#ffa500�����F(green,yellow�ł͌��Â炩����)
                    List<string> toppinList = new List<string>
                    { "�g�}�g",
                      "�ʎq",
                      "�L���x�c",
                      "�x�[�R��",
                      "�`�[�Y",
                      "�p�e�B"
                    };

                    for (int i = 0; i < oppToppings.Length; i++)
                    {
                        toppinList.Remove(oppToppings[i].nameText);
                    }
                    {
                        yield return new WaitForSeconds(speechTime);

                        int randomID = UnityEngine.Random.Range(0, toppinList.Count);
                        resultText = toppinList[randomID].ToString() + "�͎g���Ă��Ȃ��B";

                        oppSpeechFlame.SetActive(true);
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);


                        WriteLog(type, -1, toppinList[randomID]);
                    }

                    break;

                //�ΐ푊��̃n���o�[�K�[�̃g�b�s���O������Ă�
                case CardKind.Sniper:

                    mySpeechFlame.SetActive(true);
                    resultText = "�g���Ă���g�b�s���O��1������";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));
                    yield return new WaitForSeconds(speechTime);
                    {
                        int randomID = UnityEngine.Random.Range(0, oppToppings.Length);
                        resultText = "�c�c" + oppToppings[randomID].nameText + "���g���Ă���B";

                        oppSpeechFlame.SetActive(true);
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);
                    }
                    break;


                //�J�u���Ă�g�b�s���O�̐��𓚂���.
                case CardKind.DoubleShot:

                    mySpeechFlame.SetActive(true);
                    resultText = "�����g�b�s���O���J�u���Ă�H";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));
                    yield return new WaitForSeconds(speechTime);

                    int count = 0;

                    if(oppToppings[0].nameText == oppToppings[1].nameText 
                        && oppToppings[1].nameText ==  oppToppings[2].nameText)
                    {
                        count = 3;
                    }
                    else if(oppToppings[0].nameText == oppToppings[1].nameText 
                        || oppToppings[1].nameText == oppToppings[2].nameText
                        || oppToppings[2].nameText == oppToppings[0].nameText)
                    {
                        count = 2;
                    }

                    if (count == 0)
                    {
                        resultText = "�J�u���Ă�g�b�s���O�͂Ȃ�";
                    }
                    else
                    {
                        resultText = count + "�̃g�b�s���O���J�u���Ă���";
                    }

                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);

                    break;


                //�ΐ푊��̃J�[�h�������_���Ɉꖇ�̂Ă�
                case CardKind.HoldUp:

                    mySpeechFlame.SetActive(true);
                    StartCoroutine(myEffectTextScript.ShowText("�J�[�h���ꖇ�̂Ă�", speechTime * 2));

                    yield return new WaitForSeconds(speechTime);

                    CardController[] cards = oppHand.GetComponentsInChildren<CardController>();

                    if (cards.Length == 0)
                    {
                        oppSpeechFlame.SetActive(true);
                        resultText = "�ւ��A�܂ʂ��߁I";
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);
                    }
                    else
                    {
                        int discardIndex = UnityEngine.Random.Range(0, cards.Length);
                        oppSpeechFlame.SetActive(true);

                        resultText = "�����c";
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));

                        yield return new WaitForSeconds(speechTime);
                        Destroy(cards[discardIndex].gameObject);

                        yield return new WaitForSeconds(speechTime);
                    }

                    break;


                //��������ʂ��O����ʂ̂ǂ��炩���o��
                case CardKind.Coin:

                    List<CardKind> cardKindList = Enum.GetValues(typeof(CardKind)).Cast<CardKind>().ToList();
                    cardKindList.Remove(CardKind.Coin);
                    Debug.Log(cardKindList.Count);
                    /*
                    List<CardKind> cardKindList = new List<CardKind>();
                    cardKindList.Add(CardKind.CoinFront);
                    cardKindList.Add(CardKind.CoinBack);
                    */
                    {
                        int randomID = UnityEngine.Random.Range(0, cardKindList.Count);
                        CardKind randomCard = cardKindList[randomID];
                        //Debug.Log(randomCard);

                        mySpeechFlame.SetActive(true);
                        resultText = "�\���o�邩�A�����o�邩�c";
                        StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);

                        mySpeechFlame.SetActive(true);
                        resultText = "�c�c";
                        StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);

                        yield return StartCoroutine(CardAbility(randomCard));
                    }

                    break;

                //������Topping�������_���ɓ���ւ���
                case CardKind.Love:

                    mySpeechFlame.SetActive(true);
                    resultText = "�ӂӂ��A����ւ������Ė������";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);

                    resultText = "���֑O:" + myToppings[0].nameText + ":" +
                        myToppings[1].nameText + ":" + myToppings[2].nameText + "\n��\n���֌�:";
                    int index;

                    //toppingList�ɑS�Ă�Topping������
                    List<ToppingModel> toppingList = new List<ToppingModel>();
                    toppingList.Add(myToppings[0]);
                    toppingList.Add(myToppings[1]);
                    toppingList.Add(myToppings[2]);

                    //toppingList���烉���_���Ȃ̂�I�сATop�ɓ���ւ���
                    index = UnityEngine.Random.Range(0, toppingList.Count);
                    myToppings[0] = toppingList[index];
                    toppingList.RemoveAt(index);
                    resultText += myToppings[0].nameText + ",";

                    //Mid�ɓ���ւ���
                    index = UnityEngine.Random.Range(0, toppingList.Count);
                    myToppings[1] = toppingList[index];
                    toppingList.RemoveAt(index);
                    resultText += myToppings[1].nameText + ",";

                    //Bot�ɓ���ւ���
                    index = UnityEngine.Random.Range(0, toppingList.Count);
                    myToppings[2] = toppingList[index];
                    toppingList.RemoveAt(index);
                    resultText += myToppings[2].nameText;

                    if (isPlayerTurn)
                    {
                        playerToppings = myToppings;
                        mySpeechFlame.SetActive(true);
                        StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime*2));
                        yield return new WaitForSeconds(speechTime*2);
                    }
                    else
                    {
                        enemyToppings = myToppings;
                        yield return new WaitForSeconds(speechTime);
                    }

                    break;
            }
        }


        //�R�[�������Ƃ��̏���
        public IEnumerator Call(ToppingModel[] myToppings)
        {
            gameFlow.NextStage();

            bool isWin = true;
            int matchCount = 0;
            resultText = "�R�[��\n";

            //myTopping��oppToppings���S�Ĉ�v����Ȃ珟��
            for (int i = 0; i < oppToppings.Length; i++)
            {
                resultText += myToppings[i].nameText+"," ;
                if(oppToppings[i].nameText == myToppings[i].nameText)
                {
                    matchCount++;
                }
                else if (oppToppings[i].nameText != myToppings[i].nameText)
                {
                    isWin = false;
                }
            }

            resultText = resultText.Remove(resultText.Length - 1, 1);//�Ō��","��������
            mySpeechFlame.SetActive(true);
            StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 4));//�����̐����o���ɃR�[�����e��\��
            yield return new WaitForSeconds(speechTime);

            oppSpeechFlame.SetActive(true);
            StartCoroutine(oppEffectTextScript.ShowText("......", speechTime)); //����̐����o����"�c�c"��\��
            yield return new WaitForSeconds(speechTime);

            resultText = matchCount + "�C�[�g";
            oppSpeechFlame.SetActive(true);
            StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime * 2));//����̐����o���ɃC�[�g����\��
            yield return new WaitForSeconds(speechTime * 2);

            currSpellCount++;
            gameFlow.isWin = isWin;

            //3�C�[�g�Ȃ�
            if(isWin)
            {
                string[] loseTexts = 
                    {
                    "���ꂽ��c",
                    "�����c�����܂ł��c",
                    "�ӂ��A�Ȃ��Ȃ�����",
                    "�����c����ȃn�Y�ł́c�I"
                }; 
                
                resultText = loseTexts[UnityEngine.Random.Range(0,loseTexts.Length)];

                oppSpeechFlame.SetActive(true);
                StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));//����̐����o���ɃC�[�g����\��
                yield return new WaitForSeconds(speechTime);
                gameFlow.NextStage();
            }

            //�����������ɂȂ����Ȃ�
            else if (maxSpellCount == currSpellCount )
            { 
                isPlayMax = true;
                gameFlow.NextStage();
            }
        }


        //�퓬�J�n���̏���
        public void BattleInit()
        {
            maxSpellCount = 1;
            currSpellCount = 0;
            speechTime = 2f;
            isPlayMax = false;

            if (gameFlow.GetState == GameState.PlayerTurn)
            {
                isPlayerTurn = true;
                playerTurnCount++;

                myToppings = playerToppings;
                mySpeechFlame = playerSpeechFlame;
                myEffectTextScript = mySpeechFlame.GetComponent<EffectTextScript>();

                oppToppings = enemyToppings;
                oppHand = enemyHand;
                oppSpeechFlame = enemySpeechFlame;
                oppEffectTextScript = oppSpeechFlame.GetComponent<EffectTextScript>();
            }

            if (gameFlow.GetState == GameState.EnemyTurn)
            {
                isPlayerTurn = false;
                enemyTurnCount++;

                myToppings = enemyToppings;
                mySpeechFlame = enemySpeechFlame;
                myEffectTextScript = mySpeechFlame.GetComponent<EffectTextScript>();

                oppToppings = playerToppings;
                oppHand = playerHand;
                oppSpeechFlame = playerSpeechFlame;
                oppEffectTextScript = oppSpeechFlame.GetComponent<EffectTextScript>();
            }
        }

        //�G�Ǝ����̃g�b�s���O�Ǝ�D��ݒ�
        public void SetInfo(ToppingModel[] toppings,GameObject hand, bool isEnemy)
        {
            if(isEnemy)
            {
                enemyToppings = toppings;
                enemyHand = hand;
            }
            else
            {
                playerToppings = toppings;
                playerHand = hand;
            }
        }

        //���O�ɃJ�[�h���ƃJ�E���g�ƃg�b�s���O�����
        void WriteLog(CardKind kind,int count,string topping )
        {
            if(!isPlayerTurn)
            {
                enemyLog.WriteLog(kind, count, topping);
            }
        }
    }
}
