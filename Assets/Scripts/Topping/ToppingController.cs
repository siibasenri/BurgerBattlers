using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BurgerBattler.Player;
using BurgerBattler.Create;

namespace BurgerBattler.Topping
{
    public class ToppingController : MonoBehaviour
    {
        public ToppingView view; // データを表示する
        public ToppingModel model; 

        //[SerializeField] PlayerInfo player;
        BurgerTogglesGroupController toggelGroup;

        private void Awake()
        {
            view = GetComponent<ToppingView>();
        }

        private void Start()
        {
            toggelGroup = GameObject.Find("Burger").GetComponent<BurgerTogglesGroupController>();
        }

        public void Init(int cardID) // カードを生成した時に呼ばれる関数
        {
            model = new ToppingModel(cardID); // カードデータを生成
            view.Show(model); // 表示
        }
    }
}