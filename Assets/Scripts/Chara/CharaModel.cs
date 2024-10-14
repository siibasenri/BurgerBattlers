using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Chara
{
    //キャラクターのデータを管理するクラス
    public class CharaModel 
    {
        public int ID;
        public CharaKind kind;
        public string name;
        public Sprite icon;
        public string explain;


        public CharaModel(int cardID) // データを受け取り、その処理
        {
            /*
             *charaEntityから情報を参照する方式(WebGLでは不可能)
            CharaEntity charaEntity = Resources.Load<CharaEntity>("CharaEntityList/Chara" + cardID); // CardEntityのパス
            
            kind = charaEntity.charaKind;
            name = charaEntity.charaName;
            icon = charaEntity.charaIcon;
            explain = charaEntity.charaExplain;
            */

            //bankから情報を参照する方式(WebGL用)
            GameObject bank = GameObject.Find("Bank");//charaDetailを入れてるところ(疑似的なResources)
            CharaDetail charaDetail = bank.GetComponent<CharaBank>().charaDetails[cardID];//CharaBankの配列にdetailを入れてる
            
            kind = charaDetail.charaKind;
            name = charaDetail.charaName;
            icon = charaDetail.charaIcon;
            explain = charaDetail.charaExplain;
        }
    }
}
