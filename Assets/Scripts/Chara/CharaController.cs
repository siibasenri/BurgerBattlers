using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Manager;
using BurgerBattler.Player;

namespace BurgerBattler.Chara
{
    //キャラクターのデータ・見た目を管理するクラス
    public class CharaController : MonoBehaviour
    {
        public CharaView view; //データを表示する
        public CharaModel model; 

        private void Awake()
        {
            view = GetComponent<CharaView>();
        }

        public void Init(int cardID) // カードを生成した時に呼ばれる関数
        {
            model = new CharaModel(cardID); // カードデータを生成
            view.Show(model); // 表示
        }
            
    }
}
