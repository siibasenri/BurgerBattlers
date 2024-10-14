using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;
using BurgerBattler.Manager;
using BurgerBattler.Card;

namespace BurgerBattler.Battle
{
    //使用したカードとそれで得た情報を扱うスクリプト
    public class BattleLog : MonoBehaviour
    {
        List<string> pow, nat, hea, removes;          //種類別トッピングのリストと、除外リスト
        int powCount, natCount, heaCount, doubleShot; //種類別トッピングの数と、被ってる食材数, unknowns;
        bool isPow, isNat, isHea;                     //各種○○主義を使用したか否か
        string snipe;                                 //スナイパーで判明したトッピングの名前
        
        private void Start()
        {
            //unknowns = 3;
            doubleShot = -1;
            snipe = "";

            isPow = false;
            isNat = false;
            isHea = false;

            powCount = -1;
            natCount = -1;
            heaCount = -1;

            removes = new List<string>();
            pow = new List<string>() { "パティ", "ベーコン" };
            nat = new List<string>() { "玉子", "チーズ" };
            hea = new List<string>() { "トマト", "キャベツ" };

        }

        //使用したカードを記録
        //カードの種類、カウント(○○主義の場合に使用)、トッピング名
        public void WriteLog(CardKind kind, int count, string topping)
        {
            switch (kind)
            {
                case CardKind.isPow:
                    if (!isPow)
                    {
                        powCount = count;

                        if(powCount == 0)
                        {
                            removes.AddRange(pow);
                        }
                        isPow = true;
                    }
                    break;

                case CardKind.isHea:
                    if (!isHea)
                    {
                        heaCount = count;

                        if (heaCount == 0)
                        {
                            removes.AddRange(hea);
                        }
                        isHea = true;
                    }
                    break;

                case CardKind.isNat:
                    if (!isNat)
                    {
                        natCount = count;

                        if (natCount == 0)
                        {
                            removes.AddRange(nat);
                        }
                        isNat = true;
                    }
                    break;

                case CardKind.Sniper:

                    snipe = topping;

                    break;

                case CardKind.DoubleShot:

                    doubleShot = count;

                    break;

                case CardKind.isNotIn:

                    removes.Add(topping);

                    break;

            }

        }

        //ログを読み取る
        public (List<string>,int,int,int,int,string) ReadLog()
        {
            return (removes, powCount, natCount, heaCount, doubleShot, snipe);
        }


    }
}
