using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;

namespace BurgerBattler.Card
{
    public class CardController : MonoBehaviour
    {
        public CardView view; // �f�[�^��\������
        public CardModel model; // �f�[�^�Ɋւ��邱�Ƃ�����

        private void Awake()
        {
            view = GetComponent<CardView>();
        }

        public void Init(int cardID,bool isPlayer) // �J�[�h�𐶐��������ɌĂ΂��֐�
        {
            model = new CardModel(cardID); //�J�[�h�f�[�^�𐶐�
            view.Show(model,isPlayer);     //�\��

            //�ΐ푊��̃J�[�h�������ꍇ
            if(!isPlayer)
            {
                this.GetComponent<CardMove>().enabled = false; //�}�E�X�ړ���J�[�\�����킹�����̏����𖳌���
            }
        }
    }
}
