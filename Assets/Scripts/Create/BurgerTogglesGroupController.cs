using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using DG.Tweening;
using BurgerBattler.Manager;
using BurgerBattler.Topping;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    public class BurgerTogglesGroupController : MonoBehaviour
    {
        [SerializeField] BurgerDecideButton decideButton;
        [SerializeField] BurgerCreateMotionController motion;
        [SerializeField] CreateButtonBase createButton;
        ToppingModel[] Toppings;


        Toggle activeToggle;
        List<Toggle> togglesList;

        private void Start()
        {
            Toppings = new ToppingModel[3];
            togglesList = new List<Toggle>();

            var toggles = this.gameObject.GetComponentsInChildren<Toggle>();

            //子のtoggleにonValueChangedにChangeを追加
            foreach (var toggle in toggles)
            {
                toggle.GetComponent<Image>().DOFade(0.2f, 1f).SetLoops(-1, LoopType.Yoyo);
                toggle.transform.DOScale(1.1f, 1.1f).SetLoops(-1, LoopType.Yoyo);

                togglesList.Add(toggle.GetComponent<Toggle>());
                toggle.GetComponent<Toggle>().onValueChanged.AddListener(Change);

            }
            //activeToggleに初期値がActiveのToggleを設定
            activeToggle = gameObject.GetComponent<ToggleGroup>().ActiveToggles().First(); 
        }

        public void Change(bool state)
        {
            if (state)
            {
                activeToggle = this.gameObject.GetComponent<ToggleGroup>().ActiveToggles().First();

                foreach (var toggle in togglesList)
                {
                    if (toggle.isOn)
                    {
                        toggle.transform.DOPause();
                        toggle.transform.DOScale(Vector2.one * 1.5f, 0.3f).SetEase(Ease.InOutBack);
                        toggle.GetComponent<Image>().DOPause();
                        toggle.GetComponent<Image>().DOFade(1, 0.1f);
                        motion.CreateMode();
                    }
                    else
                    {
                        toggle.transform.localScale = Vector2.one;
                    }
                }
            }
        }

        //引数のmodelをバーガーにセット
        public void SetPlayerTopping(ToppingModel model)
        {
            Image toggleImage = activeToggle.GetComponent<Image>();
            toggleImage.sprite = model.icon;

            
            switch (activeToggle.name)
            {
                case "TopFood":
                    Toppings[0] = model;
                    break;

                case "MidFood":
                    Toppings[1] = model;
                    break;

                case "BotFood":
                    Toppings[2] = model;
                    break;
            }

            bool isNull = Toppings.Contains(null);

            if (!isNull)
            {
                decideButton.gameObject.SetActive(true);
                createButton.BurgerCreate(Toppings);
            }
        }
    }
}
