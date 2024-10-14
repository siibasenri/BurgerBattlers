using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


namespace BurgerBattler.Chara
{　
    //キャラクター選択用のToggleのクラス
    public class CharaToggleGroupContorller : MonoBehaviour
    {
        List<Toggle> togglesList = new List<Toggle>();
        public CharaModel model;
        //[SerializeField] CharaDetail detail;
        [SerializeField] GameObject selectButton;


        private void Start()
        {
            model = new CharaModel(0); //初期化
        }

        public void SetToggleGroup()
        {
            var toggles = this.gameObject.GetComponentsInChildren<Transform>(); //子のtoggleを全部取得
            
            foreach (var toggle in toggles)
            {
                if (toggle.GetComponent<Toggle>() != null)
                {
                    togglesList.Add(toggle.GetComponent<Toggle>());
                    toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change);  //ChangeをonValueChangeに設定
                    toggle.GetComponent<Toggle>().group = GetComponent<ToggleGroup>(); //toggleのgroupをこのobjectに設定
                }
            }
        }

        public void Change(bool state)
        {
            //選ばれたToggleのみが呼び出される
            if (state)
            {
                foreach (var toggle in togglesList)
                {
                    //選ばれたToggleだったら
                    if (toggle.isOn)
                    {
                        model = toggle.GetComponent<CharaController>().model; //modelに代入
                        toggle.transform.DOScale(Vector2.one * 1.1f, 0.1f).SetEase(Ease.OutBounce); //大きく表示
                    }
                    //それ以外だったら
                    else
                    {
                        toggle.transform.DOScale(Vector2.one, 0.1f).SetEase(Ease.OutBounce);
                    }
                }
                selectButton.SetActive(true); //決定ボタンを表示
            }
        }
    }
}
