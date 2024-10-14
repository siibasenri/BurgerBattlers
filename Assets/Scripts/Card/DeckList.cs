using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;

namespace BurgerBattler.Card
{
    //自分のデッキに何が入っているかを管理するクラス
    public class DeckList : MonoBehaviour
    {
        public List<int> cards; //カードのリスト
        public int deckSize;  //デッキ枚数

        private void Start()
        {
            cards = new List<int> { 5, 6, 7, 8 };
            deckSize = 5;
        }

        //選んだキャラに対応するカードをデッキに追加
        public void AddCharaCard(PlayerInfo player)
        {
            switch(player.playerCharactor.kind)
            {
                case Chara.CharaKind.CowBoy:
                    cards.Add(0);
                    break;

                case Chara.CharaKind.CowGirl:
                    cards.Add(1);
                    break;

                case Chara.CharaKind.Guard:
                    cards.Add(2);
                    break;

                case Chara.CharaKind.SaloonGirl:
                    cards.Add(3);
                    break;

                case Chara.CharaKind.Gambler:
                    cards.Add(4);
                    break;
            }
        }
    }
}
