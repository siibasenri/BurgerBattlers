using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    public class BGMManager : MonoBehaviour
    {
        [SerializeField] AudioClip lobbyBGM;
        [SerializeField] AudioClip battleBGM;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void PlayLobbyBGM()
        {
            audioSource.clip = lobbyBGM;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }

        public void PlayBattleBGM()
        {
            audioSource.clip = battleBGM;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }

        public void FadeOut()
        {
            int vol = 0;
            float time = 1f;
            audioSource.DOFade(vol, time);
        }
    }
}
