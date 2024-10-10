using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BurgerBattler.Chara
{
    
    public class CharaSpawn :MonoBehaviour
    {
        [SerializeField] GameObject place, charaPrefab;
        [SerializeField] CharaBank bank;

        public void AllCharaCreate()
        {
            /*
            DirectoryInfo dir = new DirectoryInfo("Assets/Resources/CharaEntityList");
            FileInfo[] info = dir.GetFiles("*.asset");
            for (int i = 0; i < info.Length; i++)
            {
                CreateChara(i, place.transform);
            }
            */

            for (int i = 0; i < bank.charaDetails.Length; i++)
            {
                CreateChara(i, place.transform);
            }

        }

        void CreateChara(int cardID, Transform place)
        {
            CharaController chara = Instantiate(charaPrefab, place).GetComponent<CharaController>();
            chara.Init(cardID);
        }
    }
}
