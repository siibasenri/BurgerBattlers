using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    public class FrontPanelController : MonoBehaviour
    {
        Vector3 firstPos;

        private void Start()
        {
            firstPos = transform.position;
        }
        public void DropPanel()
        {
            Vector3 dropPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
            this.transform.DOMove(dropPos, 1f).SetEase(Ease.OutBounce);
        }

        public void UpPanel()
        {
            transform.position = firstPos;
        }
    }
}
