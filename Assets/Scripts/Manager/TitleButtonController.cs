using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

//リザルト画面からスタート画面に戻るボタン
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

    //カーソルが合ったら大きくする
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
    }

    //カーソルが外れたら小さくする
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
    }

    //タイトル画面に戻る
    IEnumerator PhaseOut()
    {
        audioSource.Play(); //ベルを鳴らす
        curtain.SetActive(true); 
        curtain.GetComponent<Image>().DOFade(1, 0.5f); //暗転
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(0); //タイトル画面をロード

    }
}
