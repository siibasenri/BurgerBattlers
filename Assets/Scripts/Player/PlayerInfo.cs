using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using BurgerBattler.Chara;
using BurgerBattler.Topping;

namespace BurgerBattler.Player
{
    public class PlayerInfo : MonoBehaviour
    {
        public CharaModel playerCharactor;
        public ToppingModel top, mid, bot;
        public ToppingModel[] burger;
        public GameObject hand;
        public bool isPayer;

        private void Start()
        {
            playerCharactor = new CharaModel(0);
            //playerCharactor = new CharaModel(detail);
            top = new ToppingModel(0);
            mid = new ToppingModel(1);
            bot = new ToppingModel(2);
            
            burger = new ToppingModel[3];

            if (transform.name == "Player") isPayer = true;
            else if (transform.name == "Enemy") isPayer = false;
        }
    }
}
