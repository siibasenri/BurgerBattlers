using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

//���U���g��ʂ���X�^�[�g��ʂɖ߂�{�^��
public class TitleButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
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

    //�J�[�\������������傫������
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
    }

    //�J�[�\�����O�ꂽ�珬��������
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
    }

    //�^�C�g����ʂɖ߂�
    IEnumerator PhaseOut()
    {
        audioSource.Play(); //�x����炷
        curtain.SetActive(true); 
        curtain.GetComponent<Image>().DOFade(1, 0.5f); //�Ó]
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0); //�^�C�g����ʂ����[�h

    }
}
