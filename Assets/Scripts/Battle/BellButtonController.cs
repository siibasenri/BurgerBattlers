using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Motion;
using BurgerBattler.Topping;
using BurgerBattler.Manager;
using BurgerBattler.Create;
using TMPro;

namespace BurgerBattler.Battle
{
    //�n���o�[�K�[���R�[������x�����������Ƃ��̃N���X
    public class BellButtonController : MonoBehaviour
    {
        [SerializeField] FrontPanelController frontPanel;�@//�o�[�K�[�쐬
        [SerializeField] MenuToggleGroupController menuToggleGroupController; //�쐬�����o�[�K�[�̃g�O��
        [SerializeField] GameFlowManager gameFlow;
        [SerializeField] AudioSource audioSource;
        [SerializeField] BurgerCreateMotionController motion; //�o�[�K�[�̓���
        [SerializeField] TextMeshProUGUI guide;

        private void Start()
        {
            frontPanel.gameObject.SetActive(true);
            GetComponent<ToppingSpawn>().AllToppingCreate();
            menuToggleGroupController.SetToggleGroup();
        }

        public void OnClick()
        {
            if (gameFlow.GetState == GameState.PlayerTurn)
            {
                guide.SetText("�\�z�����n���o�[�K�[������Ă�������");
                motion.InitMode(); //�R�[���p�l����������Ԃɐݒ�
                audioSource.Play(); //SE�Đ�
                frontPanel.DropPanel(); //�쐬�p�l�����ォ�牺�ɗ��Ƃ�
            }
        }
    }
}
