using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BurgerBattler.Chara
{
    //キャラクターを生成するクラス   
    public class CharaSpawn :MonoBehaviour
    {
        [SerializeField] GameObject place, charaPrefab;　//生成場所とキャラクターのプレハブ
        [SerializeField] CharaBank bank; //キャラクター一覧を持つクラス

        //全てのキャラクターを生成する関数
        public void AllCharaCreate()
        {
            /*
             * フォルダ内の情報を参照して生成する手法(WebGLでは不可)
            DirectoryInfo dir = new DirectoryInfo("Assets/Resources/CharaEntityList");
            FileInfo[] info = dir.GetFiles("*.asset");
            for (int i = 0; i < info.Length; i++)
            {
                CreateChara(i, place.transform);
            }
            */

            //bankから生成する手法(WebGL用)
            for (int i = 0; i < bank.charaDetails.Length; i++)
            {
                CreateChara(i, place.transform);
            }

        }

        //指定したキャラを生成する関数
        void CreateChara(int cardID, Transform place)
        {
            CharaController chara = Instantiate(charaPrefab, place).GetComponent<CharaController>();
            chara.Init(cardID);
        }
    }
}
