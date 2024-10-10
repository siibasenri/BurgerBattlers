using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    public class InteriorMotionScript : MonoBehaviour
    {
        public void PutInterior()
        {
            this.transform.DOMove(new Vector3(5f, 0f, 0f), 3f);
        }
    }
}
