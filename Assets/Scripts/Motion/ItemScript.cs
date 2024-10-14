using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace BurgerBattler.Motion
{
    //�ΐ펞�̃A�C�e�����ړ�������N���X
    public class ItemScript : MonoBehaviour
    {
        public float dropPos;
        [SerializeField] AudioClip dropSE;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        //�A�C�e�����ړ�������֐�
        public void Drop()
        {
            audioSource.clip = dropSE;
            audioSource.Play();

            //�G�e�̏ꍇ�A���ɃX���C�h������
            if (this.transform.tag == "Enemy")
            {
                transform.DOMove(new Vector2(dropPos, transform.position.y), 0.3f).SetEase(Ease.OutQuart);
            }

            //���̑��̃A�C�e���̏ꍇ�A�ォ�痎�Ƃ�
            else
            {
                transform.DOMove(new Vector2(transform.position.x, dropPos), 0.3f).SetEase(Ease.OutBounce);
            }
        }

    }
}
