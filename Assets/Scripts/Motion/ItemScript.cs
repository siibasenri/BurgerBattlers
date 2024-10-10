using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemScript : MonoBehaviour
{
    public float dropPos;
    [SerializeField] AudioClip dropSE;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Drop()
    {
        audioSource.clip = dropSE;
        audioSource.Play();

        if (this.transform.tag == "Enemy")
        {
            transform.DOMove(new Vector2(dropPos, transform.position.y), 0.3f).SetEase(Ease.OutQuart);
        }
        else
        {
            transform.DOMove(new Vector2(transform.position.x, dropPos), 0.3f).SetEase(Ease.OutBounce);
        }
    }

}
