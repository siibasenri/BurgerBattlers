using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Chara;

namespace BurgerBattler.Manager
{
    public class SelectButtonObserver : MonoBehaviour//,IObserver
    {
        public GameFlowManager gameFlow;
        public CharaSelectButton charaSelectButton;
        //bool isCharaSelect;

        void Start()
        {
            charaSelectButton = FindObjectOfType<CharaSelectButton>();
            //charaSelectButton.Attach(this);
            
            //isCharaSelect = false;
        }

        void OnDestroy()
        {
            //charaSelectButton.Detach(this);
        }

        public void Update()
        {
        }

    }
}
