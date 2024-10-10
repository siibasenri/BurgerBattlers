using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;
using BurgerBattler.Manager;
using BurgerBattler.Card;

namespace BurgerBattler.Battle
{
    public class BattleLog : MonoBehaviour
    {
        List<string> pow, nat, hea, removes;
        int powCount, natCount, heaCount, doubleShot, unknowns;
        bool isPow, isNat, isHea;
        string snipe;
        
        private void Start()
        {
            unknowns = 3;
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
            /*
            toppings = new List<string>();
            toppings.AddRange(pow);
            toppings.AddRange(nat);
            toppings.AddRange(hea);
            */

        }

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
                            //toppings.RemoveAll(item => hea.Contains(item));
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
                            //toppings.RemoveAll(item => nat.Contains(item));
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

                    //toppings.Remove(topping);
                    removes.Add(topping);

                    break;

            }
            //Debug.Log("removeNum:" + removes.Count + "powCount" + powCount);

        }
        public (List<string>,int,int,int,int,string) ReadLog()
        {
            return (removes, powCount, natCount, heaCount, doubleShot, snipe);
        }


    }
}
