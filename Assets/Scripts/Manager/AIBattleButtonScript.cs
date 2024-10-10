using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    public class AIBattleButtonScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] GameObject curtain;
        AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }
        public void OnClick()
        {
            StartCoroutine(PhaseOut());
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
        }

        IEnumerator PhaseOut()
        {
            audioSource.Play();
            curtain.SetActive(true);
            curtain.GetComponent<Image>().DOFade(1,0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(1);

        }
    }
}
