using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    //BGM���Ǘ�����N���X
    public class BGMManager : MonoBehaviour
    {
        [SerializeField] AudioClip lobbyBGM;
        [SerializeField] AudioClip battleBGM;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        //�o�[�K�[�쐬��L�����I������BGM
        public void PlayLobbyBGM()
        {
            audioSource.clip = lobbyBGM;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }

        //�ΐ펞��BGM
        public void PlayBattleBGM()
        {
            audioSource.clip = battleBGM;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }

        //������艹������
        public void FadeOut()
        {
            int vol = 0;
            float time = 1f;
            audioSource.DOFade(vol, time);
        }
    }
}
