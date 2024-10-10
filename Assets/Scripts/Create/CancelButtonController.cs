using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    public class CancelButtonController : MonoBehaviour
    {
        [SerializeField] BurgerCreateMotionController motion;
        [SerializeField] GameObject createButton;
        [SerializeField] TextMeshProUGUI guide;
        [SerializeField] string text;
        public void OnClick()
        {
            guide.SetText(text);
            motion.CreateMode();
            createButton.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
