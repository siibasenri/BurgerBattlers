using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    //�쐬�����o�[�K�[��������(�L�����Z����)����{�^���̃N���X
    public class BurgerDecideButton : MonoBehaviour
    {
        [SerializeField] BurgerCreateMotionController motion;
        [SerializeField] GameObject createButton, cancelButton;
        [SerializeField] TextMeshProUGUI guide;
        

        public void OnClick()
        {
            motion.BurgerCompleteMode(); //�o�[�K�[���d�˂�
            createButton.SetActive(true); //�{���肷��{�^����\��
            cancelButton.SetActive(true); //�L�����Z���{�^����\��
            this.gameObject.SetActive(false); //���̃{�^�����\��
            guide.SetText("����ł�낵���ł����H"); //�����e�L�X�g�Ɋm�F����\��
        }
    }
}
