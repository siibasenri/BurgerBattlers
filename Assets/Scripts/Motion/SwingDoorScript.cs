using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

namespace BurgerBattler.Motion
{
    //対戦開始時にスウィングドアを開けるクラス
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
            telop.SetText("Ready…");
        }

        public void OpenDoor()
        {
            enabled = true;

            telop.SetText("FIGHT!");

            //ドアを開けて、横に移動させる
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].transform.DOLocalMoveX(1000 * -1 * doors[i].transform.localScale.x, 1f); //ドアを開く
                doors[i].transform.DOScaleX(0, 2f); //横に移動
            }
            //ドア横の柱を横に移動させる
            for (int i = 0; i < flames.Length; i++)
            {
                flames[i].transform.DOLocalMoveX(1000 * -1 * flames[i].transform.localScale.x, 1f);
            }
            audioSource.Play();
        }
    }
}
