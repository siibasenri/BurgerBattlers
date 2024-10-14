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
        [SerializeField] GameFlowManager gameFlow;       //ゲームの流れ
        [SerializeField] GameObject enemySpeechFlame, playerSpeechFlame;//敵のセリフの吹き出し
        [SerializeField] BattleLog enemyLog;

        public bool isPlayerTurn,isPlayMax;                        //プレイヤーのターンか
        public int playerTurnCount,enemyTurnCount;

        GameObject oppHand,playerHand, enemyHand;        //プレイヤーと自分の手札がある所
        ToppingModel[] oppToppings, myToppings, enemyToppings, playerToppings; //自分から見た、敵のtoppingリスト
        EffectTextScript oppEffectTextScript,myEffectTextScript;               
        GameObject oppSpeechFlame,mySpeechFlame;

        int maxSpellCount,currSpellCount;                //唱えられるカードの上限と、現在唱えたカード数
        float speechTime;                               //カード使用やコールの演出にかける時間
        string resultText;                               //吹き出しに表示するテキスト



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

        //カードが唱えられた時の処理
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

        //カード毎の効果処理
        IEnumerator CardAbility(CardKind type)
        {

            yield return new WaitForSeconds(1f);
            switch (type)
            {

                //対戦相手がPow属性のToppingを使っているか
                case CardKind.isPow:

                    mySpeechFlame.SetActive(true);
                    resultText = "ベーコンとパティの数は？";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    resultText = "ベーコンとパティは使ってない。";
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
                        resultText = "ベーコンとパティを合計" +
                            "<color=red>" + powCount.ToString() + "</color>" + "個使っている。";
                    }
                    yield return new WaitForSeconds(speechTime);
                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);

                    WriteLog(type, powCount, "");
                    break;


                //対戦相手がHea属性のToppingを使っているか
                case CardKind.isHea:
                    mySpeechFlame.SetActive(true);
                    resultText = "トマトとキャベツの数は？";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    resultText = "トマトとキャベツは使ってない。";
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
                        resultText = "トマトとキャベツを合計" +
                            "<color=red>" + heaCount + "</color>" + "個使っている。";
                    }
                    yield return new WaitForSeconds(speechTime);
                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);


                    WriteLog(type, heaCount, "");
                    break;


                //対戦相手がNat属性のToppingを使っているか
                case CardKind.isNat:
                    mySpeechFlame.SetActive(true);
                    resultText = "チーズと玉子の数は？";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    int natCount = 0;
                    resultText = "チーズと玉子は使ってない。";

                    for (int i = 0; i < oppToppings.Length; i++)
                    {
                        if (oppToppings[i].toppingKind == ToppingKind.NAT)
                        {
                            natCount++;
                        }
                    }

                    if (natCount != 0)
                    {
                        resultText = "チーズと玉子を合計" +
                            "<color=red>" + natCount + "</color>" + "個使っている。";
                    }
                    yield return new WaitForSeconds(speechTime);
                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);


                    WriteLog(type, natCount, "");
                    break;


                //対戦相手が使用していないトッピングをランダムに一つ教えてくれる。
                case CardKind.isNotIn:

                    mySpeechFlame.SetActive(true);
                    resultText = "使ってないトッピングは？";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));

                    //#228b22が緑、#ffa500が黄色(green,yellowでは見づらかった)
                    List<string> toppinList = new List<string>
                    { "トマト",
                      "玉子",
                      "キャベツ",
                      "ベーコン",
                      "チーズ",
                      "パティ"
                    };

                    for (int i = 0; i < oppToppings.Length; i++)
                    {
                        toppinList.Remove(oppToppings[i].nameText);
                    }
                    {
                        yield return new WaitForSeconds(speechTime);

                        int randomID = UnityEngine.Random.Range(0, toppinList.Count);
                        resultText = toppinList[randomID].ToString() + "は使っていない。";

                        oppSpeechFlame.SetActive(true);
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);


                        WriteLog(type, -1, toppinList[randomID]);
                    }

                    break;

                //対戦相手のハンバーガーのトッピングを一つ当てる
                case CardKind.Sniper:

                    mySpeechFlame.SetActive(true);
                    resultText = "使っているトッピングを1つ言いな";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 2));
                    yield return new WaitForSeconds(speechTime);
                    {
                        int randomID = UnityEngine.Random.Range(0, oppToppings.Length);
                        resultText = "……" + oppToppings[randomID].nameText + "を使っている。";

                        oppSpeechFlame.SetActive(true);
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);
                    }
                    break;


                //カブってるトッピングの数を答える.
                case CardKind.DoubleShot:

                    mySpeechFlame.SetActive(true);
                    resultText = "いくつトッピングがカブってる？";
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
                        resultText = "カブってるトッピングはない";
                    }
                    else
                    {
                        resultText = count + "個のトッピングがカブっている";
                    }

                    oppSpeechFlame.SetActive(true);
                    StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);

                    break;


                //対戦相手のカードをランダムに一枚捨てる
                case CardKind.HoldUp:

                    mySpeechFlame.SetActive(true);
                    StartCoroutine(myEffectTextScript.ShowText("カードを一枚捨てな", speechTime * 2));

                    yield return new WaitForSeconds(speechTime);

                    CardController[] cards = oppHand.GetComponentsInChildren<CardController>();

                    if (cards.Length == 0)
                    {
                        oppSpeechFlame.SetActive(true);
                        resultText = "へっ、まぬけめ！";
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);
                    }
                    else
                    {
                        int discardIndex = UnityEngine.Random.Range(0, cards.Length);
                        oppSpeechFlame.SetActive(true);

                        resultText = "ちっ…";
                        StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));

                        yield return new WaitForSeconds(speechTime);
                        Destroy(cards[discardIndex].gameObject);

                        yield return new WaitForSeconds(speechTime);
                    }

                    break;


                //当たり効果か外れ効果のどちらかが出る
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
                        resultText = "表が出るか、裏が出るか…";
                        StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);

                        mySpeechFlame.SetActive(true);
                        resultText = "……";
                        StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime));
                        yield return new WaitForSeconds(speechTime);

                        yield return StartCoroutine(CardAbility(randomCard));
                    }

                    break;

                //自分のToppingをランダムに入れ替える
                case CardKind.Love:

                    mySpeechFlame.SetActive(true);
                    resultText = "ふふっ、入れ替えさせて貰ったよ";
                    StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime));
                    yield return new WaitForSeconds(speechTime);

                    resultText = "入替前:" + myToppings[0].nameText + ":" +
                        myToppings[1].nameText + ":" + myToppings[2].nameText + "\n↓\n入替後:";
                    int index;

                    //toppingListに全てのToppingを入れる
                    List<ToppingModel> toppingList = new List<ToppingModel>();
                    toppingList.Add(myToppings[0]);
                    toppingList.Add(myToppings[1]);
                    toppingList.Add(myToppings[2]);

                    //toppingListからランダムなのを選び、Topに入れ替える
                    index = UnityEngine.Random.Range(0, toppingList.Count);
                    myToppings[0] = toppingList[index];
                    toppingList.RemoveAt(index);
                    resultText += myToppings[0].nameText + ",";

                    //Midに入れ替える
                    index = UnityEngine.Random.Range(0, toppingList.Count);
                    myToppings[1] = toppingList[index];
                    toppingList.RemoveAt(index);
                    resultText += myToppings[1].nameText + ",";

                    //Botに入れ替える
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


        //コールしたときの処理
        public IEnumerator Call(ToppingModel[] myToppings)
        {
            gameFlow.NextStage();

            bool isWin = true;
            int matchCount = 0;
            resultText = "コール\n";

            //myToppingとoppToppingsが全て一致するなら勝ち
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

            resultText = resultText.Remove(resultText.Length - 1, 1);//最後の","だけ消す
            mySpeechFlame.SetActive(true);
            StartCoroutine(myEffectTextScript.ShowText(resultText, speechTime * 4));//自分の吹き出しにコール内容を表示
            yield return new WaitForSeconds(speechTime);

            oppSpeechFlame.SetActive(true);
            StartCoroutine(oppEffectTextScript.ShowText("......", speechTime)); //相手の吹き出しに"……"を表示
            yield return new WaitForSeconds(speechTime);

            resultText = matchCount + "イート";
            oppSpeechFlame.SetActive(true);
            StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime * 2));//相手の吹き出しにイート数を表示
            yield return new WaitForSeconds(speechTime * 2);

            currSpellCount++;
            gameFlow.isWin = isWin;

            //3イートなら
            if(isWin)
            {
                string[] loseTexts = 
                    {
                    "やられたよ…",
                    "ちっ…ここまでか…",
                    "ふっ、なかなかやるな",
                    "くっ…こんなハズでは…！"
                }; 
                
                resultText = loseTexts[UnityEngine.Random.Range(0,loseTexts.Length)];

                oppSpeechFlame.SetActive(true);
                StartCoroutine(oppEffectTextScript.ShowText(resultText, speechTime));//相手の吹き出しにイート数を表示
                yield return new WaitForSeconds(speechTime);
                gameFlow.NextStage();
            }

            //唱えられる上限になったなら
            else if (maxSpellCount == currSpellCount )
            { 
                isPlayMax = true;
                gameFlow.NextStage();
            }
        }


        //戦闘開始時の処理
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

        //敵と自分のトッピングと手札を設定
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

        //ログにカード情報とカウントとトッピングを入力
        void WriteLog(CardKind kind,int count,string topping )
        {
            if(!isPlayerTurn)
            {
                enemyLog.WriteLog(kind, count, topping);
            }
        }
    }
}
