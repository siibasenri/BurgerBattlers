using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    //ゲーム開始ボタンのクラス
    public class AIBattleButtonScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] GameObject curtain; //ゲーム開始時の暗転用オブジェクト
        AudioSource audioSource; //SEを流す用のaudioSource

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void OnClick()
        {
            StartCoroutine(PhaseOut());
        }

        //カーソルがあったとき、大きくする
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
        }

        //カーソルが外れたとき、小さくする
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
        }

        //ゲーム開始用関数
        IEnumerator PhaseOut()
        {
            audioSource.Play(); //ベルを鳴らす
            curtain.SetActive(true);
            curtain.GetComponent<Image>().DOFade(1,0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(1); //ゲーム開始シーンをロード

        }
    }
}
