using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace BurgerBattler.Motion
{
    public class ItemDropScript : MonoBehaviour
    {
        [SerializeField] ItemScript[] items;

        private void Start()
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].transform.tag == "Enemy")
                {
                    items[i].GetComponent<ItemScript>().dropPos = items[i].transform.position.x;
                    items[i].transform.position = new Vector2(transform.position.x, items[i].transform.position.y);
                }
                else
                {
                    items[i].GetComponent<ItemScript>().dropPos = items[i].transform.position.y;
                    items[i].transform.position = new Vector2(items[i].transform.position.x, transform.position.y);
                }
            }
        }

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
