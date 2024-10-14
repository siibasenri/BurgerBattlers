using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BurgerBattler.Topping;

namespace BurgerBattler.Create
{
    //メニュー表のトッピングのコントローラークラス
    public class MenuToggleGroupController : MonoBehaviour
    {
        List<Toggle> togglesList = new List<Toggle>();
        [SerializeField] BurgerTogglesGroupController burgerTogglesGroupController;
        [SerializeField] TextMeshProUGUI explainText;
        [SerializeField] Image toppingImage;
        ToppingModel model;

        //子のToggleのonValueChangedにChangeを追加し、ToggleGroupを設定
        public void SetToggleGroup()
        {
            var toggles = this.gameObject.GetComponentsInChildren<Transform>();
            foreach (var toggle in toggles)
            {
                if (toggle.GetComponent<Toggle>() != null)
                {
                    togglesList.Add(toggle.GetComponent<Toggle>()); 
                    toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change); //Change()を追加
                    toggle.GetComponent<Toggle>().group = GetComponent<ToggleGroup>(); //toggleのgroupをこのobjectに設定
                }
            }
        }

        //クリックしたToppingをmodelに代入
        public void Change(bool state)
        {
            if (state)
            {
                foreach (var toggle in togglesList)
                {
                    //選択されてるtoggleだったら
                    if (toggle.isOn)
                    {
                        model = toggle.GetComponent<ToppingController>().model; 

                        burgerTogglesGroupController.SetPlayerTopping(model); //選んだトッピングをバーガーにセット
                        explainText.SetText(model.explainText); //説明文を表示
                        toppingImage.sprite = model.icon;       //アイコンを表示
                    }
                }
            }
        }
    }
}
