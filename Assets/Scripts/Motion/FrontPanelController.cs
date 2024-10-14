using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //操作用のパネルを移動するクラス
    public class FrontPanelController : MonoBehaviour
    {
        Vector3 firstPos;

        private void Start()
        {
            firstPos = transform.position;
        }
        //上からパネルを落とす
        public void DropPanel()
        {
            Vector3 dropPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
            this.transform.DOMove(dropPos, 1f).SetEase(Ease.OutBounce);
        }

        //パネルを元の位置に戻す
        public void UpPanel()
        {
            transform.position = firstPos;
        }
    }
}
