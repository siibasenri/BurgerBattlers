using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Topping
{
    public class ToppingView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] Image icon;

        public void Show(ToppingModel toppingModel)
        {
            nameText.text = toppingModel.nameText;
            icon.sprite = toppingModel.icon;
        }
    }
}
