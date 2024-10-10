using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Manager;
using BurgerBattler.Player;

namespace BurgerBattler.Chara
{
    public class CharaController : MonoBehaviour
    {
        public CharaView view; // データを表示する
        public CharaModel model;
        CharaDetail detail;

        private void Awake()
        {
            view = GetComponent<CharaView>();
            //detail = GetComponent<CharaDetail>();
        }

        public void Init(int cardID) // カードを生成した時に呼ばれる関数
        {
            model = new CharaModel(cardID); // カードデータを生成
            //model = new CharaModel(detail);
            view.Show(model); // 表示
        }
            
    }
}
