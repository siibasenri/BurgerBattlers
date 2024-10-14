using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BurgerBattler.Topping
{
    //トッピングの情報から対応するデータを代入するクラス
    public class ToppingModel 
    {
        public string ID;
        public string nameText;
        public string explainText;
        public ToppingKind toppingKind;
        public Sprite icon;

        public ToppingModel(int toppingID)
        {
            /* ToppingEntityから情報を参照する方法(WebGLでは不可)
            ToppingEntity toppingEntity = Resources.Load<ToppingEntity>("ToppingEntityList/Topping" + toppingID); // CardEntityのパス
            */

            //Bankに登録されている情報を参照する方法(WebGL用)
            GameObject bank = GameObject.Find("Bank");
            ToppingDetail toppingDetail = bank.GetComponent<ToppingBank>().toppingDetails[toppingID];

            nameText = toppingDetail.nameText;
            explainText = toppingDetail.explainText;
            toppingKind = toppingDetail.toppingKind;
            icon = toppingDetail.iconSprite;
        }

    }
}
