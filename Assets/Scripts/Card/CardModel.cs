using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Card

    //�J�[�h�̃f�[�^���Ǘ�����N���X
{    public class CardModel 
    {
        public string name, explain; //���O�Ɛ�����
        public Sprite icon, back, rev; //�A�C�R���Ɣw�i�Ɨ���
        public CardKind kind; //�J�[�h���

        public bool isPlayersCard; //�v���C���[�̃J�[�h���ۂ�


        public CardModel(int cardID)
        {
            /*
            CardEntity��������Q�Ƃ�����@(WebGL�ł͕s��)
            CardEntity cardEntity = Resources.Load<CardEntity>("CardEntityList/Card" + cardID); // CardEntity�̃p�X
            */

            //bank����cardDetail���Q�Ƃ�����@(WebGL�p)
            GameObject bank = GameObject.Find("Bank");
            CardDetail cardDetail = bank.GetComponent<CardBank>().cardDetails[cardID];

            name = cardDetail.nameText;
            icon = cardDetail.iconSprite;
            explain = cardDetail.explainText;
            back = cardDetail.backSprite;
            rev = cardDetail.revSprite;
            kind = cardDetail.kind;
        }
    }
}
