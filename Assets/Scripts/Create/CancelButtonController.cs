using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using BurgerBattler.Motion;

namespace BurgerBattler.Create
{
    //�쐬�����o�[�K�[���L�����Z������{�^���̃N���X
    public class CancelButtonController : MonoBehaviour
    {
        [SerializeField] BurgerCreateMotionController motion; //�o�[�K�[�̓������Ǘ�����N���X
        [SerializeField] GameObject createButton; //������{�^���̃N���X
        [SerializeField] TextMeshProUGUI guide; //��������\������e�L�X�g
        [SerializeField] string text; //������

        public void OnClick()
        {
            guide.SetText(text);
            motion.CreateMode(); //�d�Ȃ��Ă����o�[�K�[���쐬��Ԃɖ߂�
            createButton.SetActive(false); //���쐬�{�^�����\��
            gameObject.SetActive(false); 
        }
    }
}
