using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace BurgerBattler.Motion
{
    //�ΐ�J�n���̃A�C�e���ړ��p�N���X
    public class ItemDropScript : MonoBehaviour
    {
        [SerializeField] ItemScript[] items;

        private void Start()
        {
            for (int i = 0; i < items.Length; i++)
            {
                //�G�e�̏ꍇ�A��ʉE�[�ɒu��
                if (items[i].transform.tag == "Enemy")
                {
                    items[i].GetComponent<ItemScript>().dropPos = items[i].transform.position.x;
                    items[i].transform.position = new Vector2(transform.position.x, items[i].transform.position.y);
                }

                //���̑��̃A�C�e���̏ꍇ�A��ʏ�ɒu��
                else
                {
                    items[i].GetComponent<ItemScript>().dropPos = items[i].transform.position.y;
                    items[i].transform.position = new Vector2(items[i].transform.position.x, transform.position.y);
                }
            }
        }

        //�A�C�e������Âړ�������
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
