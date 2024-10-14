using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace BurgerBattler.Motion
{
    //対戦時のアイテムを移動させるクラス
    public class ItemScript : MonoBehaviour
    {
        public float dropPos;
        [SerializeField] AudioClip dropSE;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        //アイテムを移動させる関数
        public void Drop()
        {
            audioSource.clip = dropSE;
            audioSource.Play();

            //敵影の場合、横にスライドさせる
            if (this.transform.tag == "Enemy")
            {
                transform.DOMove(new Vector2(dropPos, transform.position.y), 0.3f).SetEase(Ease.OutQuart);
            }

            //その他のアイテムの場合、上から落とす
            else
            {
                transform.DOMove(new Vector2(transform.position.x, dropPos), 0.3f).SetEase(Ease.OutBounce);
            }
        }

    }
}
