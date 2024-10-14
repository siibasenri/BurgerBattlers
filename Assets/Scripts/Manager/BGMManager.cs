using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    //BGMを管理するクラス
    public class BGMManager : MonoBehaviour
    {
        [SerializeField] AudioClip lobbyBGM;
        [SerializeField] AudioClip battleBGM;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        //バーガー作成やキャラ選択時のBGM
        public void PlayLobbyBGM()
        {
            audioSource.clip = lobbyBGM;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }

        //対戦時のBGM
        public void PlayBattleBGM()
        {
            audioSource.clip = battleBGM;
            audioSource.volume = 0.25f;
            audioSource.Play();
        }

        //ゆっくり音を消す
        public void FadeOut()
        {
            int vol = 0;
            float time = 1f;
            audioSource.DOFade(vol, time);
        }
    }
}
