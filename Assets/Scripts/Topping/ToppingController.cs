using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BurgerBattler.Player;
using BurgerBattler.Create;

namespace BurgerBattler.Topping
{
    //�g�b�s���O�̃f�[�^�E�����ڂ��Ǘ�����N���X
    public class ToppingController : MonoBehaviour
    {
        public ToppingView view; // �f�[�^��\������
        public ToppingModel model; 

        BurgerTogglesGroupController toggelGroup;

        private void Awake()
        {
            view = GetComponent<ToppingView>();
        }

        private void Start()
        {
            toggelGroup = GameObject.Find("Burger").GetComponent<BurgerTogglesGroupController>();
        }

        public void Init(int cardID) // �J�[�h�𐶐��������ɌĂ΂��֐�
        {
            model = new ToppingModel(cardID); // �J�[�h�f�[�^�𐶐�
            view.Show(model); // �\��
        }
    }
}