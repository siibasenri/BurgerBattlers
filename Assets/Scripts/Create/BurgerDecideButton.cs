using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    public class BurgerDecideButton : MonoBehaviour
    {
        [SerializeField] BurgerCreateMotionController motion;
        [SerializeField] GameObject createButton, cancelButton;
        [SerializeField] TextMeshProUGUI guide;
        

        public void OnClick()
        {
            motion.BurgerCompleteMode();
            createButton.SetActive(true);
            cancelButton.SetActive(true);
            this.gameObject.SetActive(false);
            guide.SetText("Ç±ÇÍÇ≈ÇÊÇÎÇµÇ¢Ç≈Ç∑Ç©ÅH");
        }
    }
}
