using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BurgerBattler.Topping
{
    //ToppingをMenuに生成するスクリプト
    public class ToppingSpawn :MonoBehaviour
    {
        [SerializeField] GameObject menu, toppingPrefab;//生成する場所、生成するPrefab
        [SerializeField] ToppingBank bank;

        //全てのToppingを生成する
        public void AllToppingCreate()
        {
            /*
            Entityファイルから情報を参照する方法(WebGLでは不可)
            DirectoryInfo dir = new DirectoryInfo("Assets/Resources/ToppingEntityList"); //生成するデータがある場所
            FileInfo[] info = dir.GetFiles("*.asset"); //ファイルをすべて取得
            for (int i = 0; i < info.Length; i++)
            {
                CreateTopping(i, menu.transform);
            }
            */

            //Bank内の情報を参照する方法(WebGL用)
            for (int i = 0; i < bank.toppingDetails.Length; i++)
            {
                CreateTopping(i, menu.transform);
            }
        }

        //一個のToppingを生成する関数
        void CreateTopping(int cardID, Transform place)
        {
            ToppingController topping = Instantiate(toppingPrefab, place).GetComponent<ToppingController>();
            topping.Init(cardID);
        }
    }
}
