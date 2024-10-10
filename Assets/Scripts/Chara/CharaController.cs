using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Manager;
using BurgerBattler.Player;

namespace BurgerBattler.Chara
{
    public class CharaController : MonoBehaviour
    {
        public CharaView view; // �f�[�^��\������
        public CharaModel model;
        CharaDetail detail;

        private void Awake()
        {
            view = GetComponent<CharaView>();
            //detail = GetComponent<CharaDetail>();
        }

        public void Init(int cardID) // �J�[�h�𐶐��������ɌĂ΂��֐�
        {
            model = new CharaModel(cardID); // �J�[�h�f�[�^�𐶐�
            //model = new CharaModel(detail);
            view.Show(model); // �\��
        }
            
    }
}
