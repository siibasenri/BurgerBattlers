using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace BurgerBattler.Motion
{
    //�ΐ�J�n���ɃX�E�B���O�h�A���J����N���X
    public class SwingDoorScript : MonoBehaviour
    {
        AudioSource audioSource;
        [SerializeField] AudioClip openSE;
        [SerializeField] GameObject[] doors,flames;
        [SerializeField] TextMeshProUGUI telop;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = openSE;
            telop.SetText("Ready�c");
        }

        public void OpenDoor()
        {
            enabled = true;

            telop.SetText("FIGHT!");

            //�h�A���J���āA���Ɉړ�������
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].transform.DOLocalMoveX(1000 * -1 * doors[i].transform.localScale.x, 1f); //�h�A���J��
                doors[i].transform.DOScaleX(0, 2f); //���Ɉړ�
            }
            //�h�A���̒������Ɉړ�������
            for (int i = 0; i < flames.Length; i++)
            {
                flames[i].transform.DOLocalMoveX(1000 * -1 * flames[i].transform.localScale.x, 1f);
            }
            audioSource.Play();
        }
    }
}
