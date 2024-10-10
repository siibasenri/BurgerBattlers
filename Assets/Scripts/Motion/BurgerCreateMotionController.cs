using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BurgerBattler.Battle;
using BurgerBattler.Topping;

namespace BurgerBattler.Motion
{
    public class BurgerCreateMotionController : MonoBehaviour
    {
        [SerializeField] GameObject burgerPanel, menuPanel,cancelButton,CreateButton;

        float burgerPos;
        float[] burgersPos;
        Transform midFood;
        Transform[] burgers;

        private void Start()
        {
            burgerPos = burgerPanel.transform.position.x;
            burgerPanel.transform.position = new Vector2(transform.position.x, burgerPanel.transform.position.y);

            burgers = burgerPanel.GetComponentsInChildren<Transform>();
            burgersPos = new float[burgers.Length];

            for (int i = 0; i < burgers.Length; i++)
            {
                burgersPos[i] = burgers[i].localPosition.y;

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
            CreateButton.SetActive(false);
            

            for (int i = 0; i < burgers.Length; i++)
            {
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

        public void InitMode()
        {
            menuPanel.SetActive(false);
            burgerPanel.transform.DOMoveX(transform.position.x, 1f);
            cancelButton.SetActive(false);
            CreateButton.SetActive(false);

            for (int i = 0; i < burgers.Length; i++)
            {
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
