using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BurgerBattler.Battle;
using BurgerBattler.Topping;

namespace BurgerBattler.Motion
{
    //パネルの動きに関するクラス
    public class BurgerCreateMotionController : MonoBehaviour
    {
        //作成したバーガーを表示しているパネル、トッピング一覧のパネル
        //決定画面から作成画面に戻るボタン、作成画面から決定画面に移行するボタン
        [SerializeField] GameObject burgerPanel, menuPanel,cancelButton,createButton;

        float burgerPos;
        float[] burgersPos;
        Transform midFood;
        Transform[] burgers;

        private void Start()
        {
            
            burgerPos = burgerPanel.transform.position.x; 
            burgerPanel.transform.position = new Vector2(transform.position.x, burgerPanel.transform.position.y);

            burgers = burgerPanel.GetComponentsInChildren<Transform>(); //バンズとトッピングを取得
            burgersPos = new float[burgers.Length];

            //バンズとトッピングの数だけ繰り返す
            for (int i = 0; i < burgers.Length; i++)
            {
                burgersPos[i] = burgers[i].localPosition.y; //初期位置を記録

                if (burgers[i].name == "MidFood")
                {
                    midFood = burgers[i];
                }

            }
            menuPanel.SetActive(false);
        }
        //完成後の重なったハンバーガーを表示するモード(トッピングのToggle無効)
        public void BurgerCompleteMode()
        {
            menuPanel.SetActive(false);
            burgerPanel.transform.DOMoveX(transform.position.x, 1f);

            for (int i = 0; i < burgers.Length; i++)
            {
                //Toggle無効化
                if (burgers[i].GetComponent<Toggle>() != null)
                {
                    burgers[i].GetComponent<Toggle>().enabled = false;
                    burgers[i].localScale = new Vector2(1.0f, 1.0f);
                }

                if (burgers[i] != burgerPanel.transform)
                {
                    burgers[i].DOMoveY(midFood.position.y, 0.3f);
                }
            }
        }

        //ハンバーガーを作成するモード(トッピングのToggle有効)
        public void CreateMode()
        {
            menuPanel.SetActive(true);
            burgerPanel.transform.DOMoveX(burgerPos, 1f);
            cancelButton.SetActive(false);
            createButton.SetActive(false);
            

            for (int i = 0; i < burgers.Length; i++)
            {
                //Toggle有効化
                if (burgers[i].GetComponent<Toggle>() != null)
                {
                    burgers[i].GetComponent<Toggle>().enabled = true;
                }

                if (burgers[i] != burgerPanel.transform)
                {
                    burgers[i].DOLocalMoveY(burgersPos[i], 0.3f);
                }

            }
        }

        //重なってない状態のハンバーガーのみを表示するモード(トッピングのToggle有効)
        public void InitMode()
        {
            menuPanel.SetActive(false); //トッピング一覧を非表示
            burgerPanel.transform.DOMoveX(transform.position.x, 1f); //作成しているバーガーを重ねる
            cancelButton.SetActive(false);  //キャンセルボタンを非表示
            createButton.SetActive(false);  //作成ボタンを非表示

            for (int i = 0; i < burgers.Length; i++)
            {
                //Toggle有効化
                if (burgers[i].GetComponent<Toggle>() != null)
                {
                    burgers[i].GetComponent<Toggle>().enabled = true;
                }

                if (burgers[i] != burgerPanel.transform)
                {
                    burgers[i].localPosition = new Vector2(burgers[i].localPosition.x, burgersPos[i]);
                }
            }
        }
    }
}
