using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using BurgerBattler.Chara;
using BurgerBattler.Topping;

namespace BurgerBattler.Player
{
    //プレイヤーの情報を管理するクラス
    public class PlayerInfo : MonoBehaviour
    {
        public CharaModel playerCharactor; //プレイヤーのキャラ
        public ToppingModel top, mid, bot; //プレイヤーの制作したバーガーの各トッピング
        public ToppingModel[] burger;      //トッピングの配列
        public GameObject hand;            //手札
        public bool isPayer;               //プレイヤーか否か

        //初期化
        private void Start()
        {
            playerCharactor = new CharaModel(0);

            top = new ToppingModel(0);
            mid = new ToppingModel(1);
            bot = new ToppingModel(2);
            
            burger = new ToppingModel[3];

            if (transform.name == "Player") isPayer = true;
            else if (transform.name == "Enemy") isPayer = false;
        }
    }
}
