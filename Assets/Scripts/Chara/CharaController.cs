using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Manager;
using BurgerBattler.Player;

namespace BurgerBattler.Chara
{
    //�L�����N�^�[�̃f�[�^�E�����ڂ��Ǘ�����N���X
    public class CharaController : MonoBehaviour
    {
        public CharaView view; //�f�[�^��\������
        public CharaModel model; 

        private void Awake()
        {
            view = GetComponent<CharaView>();
        }

        public void Init(int cardID) // �J�[�h�𐶐��������ɌĂ΂��֐�
        {
            model = new CharaModel(cardID); // �J�[�h�f�[�^�𐶐�
            view.Show(model); // �\��
        }
            
    }
}
