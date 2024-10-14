using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace BurgerBattler.Motion
{
    //対戦開始時のアイテム移動用クラス
    public class ItemDropScript : MonoBehaviour
    {
        [SerializeField] ItemScript[] items;

        private void Start()
        {
            for (int i = 0; i < items.Length; i++)
            {
                //敵影の場合、画面右端に置く
                if (items[i].transform.tag == "Enemy")
                {
                    items[i].GetComponent<ItemScript>().dropPos = items[i].transform.position.x;
                    items[i].transform.position = new Vector2(transform.position.x, items[i].transform.position.y);
                }

                //その他のアイテムの場合、画面上に置く
                else
                {
                    items[i].GetComponent<ItemScript>().dropPos = items[i].transform.position.y;
                    items[i].transform.position = new Vector2(items[i].transform.position.x, transform.position.y);
                }
            }
        }

        //アイテムを一個づつ移動させる
        public IEnumerator DropItem()
        {
            for (int i = 0; i < items.Length; i++)
            {
                yield return new WaitForSeconds(0.5f);
                ItemScript item = items[i];
                item.Drop();
            }
        }
    }
}
