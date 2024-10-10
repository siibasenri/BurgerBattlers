using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Chara
{
    public class CharaModel 
    {
        public int ID;
        public CharaKind kind;
        public string name;
        public Sprite icon;
        public string explain;


        public CharaModel(int cardID) // �f�[�^���󂯎��A���̏���
        {
            /*
            CharaEntity charaEntity = Resources.Load<CharaEntity>("CharaEntityList/Chara" + cardID); // CardEntity�̃p�X
            
            kind = charaEntity.charaKind;
            name = charaEntity.charaName;
            icon = charaEntity.charaIcon;
            explain = charaEntity.charaExplain;
            */
            GameObject bank = GameObject.Find("Bank");//charaDetail�����Ă�Ƃ���(�^���I��Resources)
            CharaDetail charaDetail = bank.GetComponent<CharaBank>().charaDetails[cardID];//CharaBank�̔z���detail�����Ă�
            
            kind = charaDetail.charaKind;
            name = charaDetail.charaName;
            icon = charaDetail.charaIcon;
            explain = charaDetail.charaExplain;
        }
    }
}
