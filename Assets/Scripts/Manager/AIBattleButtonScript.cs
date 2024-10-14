using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    //�Q�[���J�n�{�^���̃N���X
    public class AIBattleButtonScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] GameObject curtain; //�Q�[���J�n���̈Ó]�p�I�u�W�F�N�g
        AudioSource audioSource; //SE�𗬂��p��audioSource

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void OnClick()
        {
            StartCoroutine(PhaseOut());
        }

        //�J�[�\�����������Ƃ��A�傫������
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
        }

        //�J�[�\�����O�ꂽ�Ƃ��A����������
        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
        }

        //�Q�[���J�n�p�֐�
        IEnumerator PhaseOut()
        {
            audioSource.Play(); //�x����炷
            curtain.SetActive(true);
            curtain.GetComponent<Image>().DOFade(1,0.5f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(1); //�Q�[���J�n�V�[�������[�h

        }
    }
}
