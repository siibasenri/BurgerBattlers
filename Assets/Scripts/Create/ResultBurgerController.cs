using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Player;
using UnityEngine.UI;

namespace BurgerBattler.Create
{
    public class ResultBurgerController : MonoBehaviour
    {
        [SerializeField] PlayerInfo player;
        [SerializeField] Image[] toppings;

        private void Update()
        {
            for(int i = 0;i<toppings.Length; i++)
            {
                toppings[i].sprite = player.burger[i].icon;
            }
        }
    }
}
