using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using BurgerBattler.Battle;
using BurgerBattler.Topping;

namespace BurgerBattler.Motion
{
    //�p�l���̓����Ɋւ���N���X
    public class BurgerCreateMotionController : MonoBehaviour
    {
        //�쐬�����o�[�K�[��\�����Ă���p�l���A�g�b�s���O�ꗗ�̃p�l��
        //�����ʂ���쐬��ʂɖ߂�{�^���A�쐬��ʂ��猈���ʂɈڍs����{�^��
        [SerializeField] GameObject burgerPanel, menuPanel,cancelButton,createButton;

        float burgerPos;
        float[] burgersPos;
        Transform midFood;
        Transform[] burgers;

        private void Start()
        {
            
            burgerPos = burgerPanel.transform.position.x; 
            burgerPanel.transform.position = new Vector2(transform.position.x, burgerPanel.transform.position.y);

            burgers = burgerPanel.GetComponentsInChildren<Transform>(); //�o���Y�ƃg�b�s���O���擾
            burgersPos = new float[burgers.Length];

            //�o���Y�ƃg�b�s���O�̐������J��Ԃ�
            for (int i = 0; i < burgers.Length; i++)
            {
                burgersPos[i] = burgers[i].localPosition.y; //�����ʒu���L�^

                if (burgers[i].name == "MidFood")
                {
                    midFood = burgers[i];
                }

            }
            menuPanel.SetActive(false);
        }
        //������̏d�Ȃ����n���o�[�K�[��\�����郂�[�h(�g�b�s���O��Toggle����)
        public void BurgerCompleteMode()
        {
            menuPanel.SetActive(false);
            burgerPanel.transform.DOMoveX(transform.position.x, 1f);

            for (int i = 0; i < burgers.Length; i++)
            {
                //Toggle������
                if (burgers[i].GetComponent<Toggle>() != null)
                {
                    burgers[i].GetComponent<Toggle>().enabled = false;
                    burgers[i].localScale = new Vector2(1.0f, 1.0f);
                }

                if (burgers[i] != burgerPanel.transform)
                {
                    burgers[i].DOMoveY(midFood.position.y, 0.3f);
                }
            }
        }

        //�n���o�[�K�[���쐬���郂�[�h(�g�b�s���O��Toggle�L��)
        public void CreateMode()
        {
            menuPanel.SetActive(true);
            burgerPanel.transform.DOMoveX(burgerPos, 1f);
            cancelButton.SetActive(false);
            createButton.SetActive(false);
            

            for (int i = 0; i < burgers.Length; i++)
            {
                //Toggle�L����
                if (burgers[i].GetComponent<Toggle>() != null)
                {
                    burgers[i].GetComponent<Toggle>().enabled = true;
                }

                if (burgers[i] != burgerPanel.transform)
                {
                    burgers[i].DOLocalMoveY(burgersPos[i], 0.3f);
                }

            }
        }

        //�d�Ȃ��ĂȂ���Ԃ̃n���o�[�K�[�݂̂�\�����郂�[�h(�g�b�s���O��Toggle�L��)
        public void InitMode()
        {
            menuPanel.SetActive(false); //�g�b�s���O�ꗗ���\��
            burgerPanel.transform.DOMoveX(transform.position.x, 1f); //�쐬���Ă���o�[�K�[���d�˂�
            cancelButton.SetActive(false);  //�L�����Z���{�^�����\��
            createButton.SetActive(false);  //�쐬�{�^�����\��

            for (int i = 0; i < burgers.Length; i++)
            {
                //Toggle�L����
                if (burgers[i].GetComponent<Toggle>() != null)
                {
                    burgers[i].GetComponent<Toggle>().enabled = true;
                }

                if (burgers[i] != burgerPanel.transform)
                {
                    burgers[i].localPosition = new Vector2(burgers[i].localPosition.x, burgersPos[i]);
                }
            }
        }
    }
}
