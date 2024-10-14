using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace BurgerBattler.Topping
{
    //�g�b�s���O�̏�񂩂�Ή�����f�[�^��������N���X
    public class ToppingModel 
    {
        public string ID;
        public string nameText;
        public string explainText;
        public ToppingKind toppingKind;
        public Sprite icon;

        public ToppingModel(int toppingID)
        {
            /* ToppingEntity��������Q�Ƃ�����@(WebGL�ł͕s��)
            ToppingEntity toppingEntity = Resources.Load<ToppingEntity>("ToppingEntityList/Topping" + toppingID); // CardEntity�̃p�X
            */

            //Bank�ɓo�^����Ă�������Q�Ƃ�����@(WebGL�p)
            GameObject bank = GameObject.Find("Bank");
            ToppingDetail toppingDetail = bank.GetComponent<ToppingBank>().toppingDetails[toppingID];

            nameText = toppingDetail.nameText;
            explainText = toppingDetail.explainText;
            toppingKind = toppingDetail.toppingKind;
            icon = toppingDetail.iconSprite;
        }

    }
}
