using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BurgerBattler.Topping
{
    //Topping��Menu�ɐ�������X�N���v�g
    public class ToppingSpawn :MonoBehaviour
    {
        [SerializeField] GameObject menu, toppingPrefab;//��������ꏊ�A��������Prefab
        [SerializeField] ToppingBank bank;

        //�S�Ă�Topping�𐶐�����
        public void AllToppingCreate()
        {
            /*
            Entity�t�@�C����������Q�Ƃ�����@(WebGL�ł͕s��)
            DirectoryInfo dir = new DirectoryInfo("Assets/Resources/ToppingEntityList"); //��������f�[�^������ꏊ
            FileInfo[] info = dir.GetFiles("*.asset"); //�t�@�C�������ׂĎ擾
            for (int i = 0; i < info.Length; i++)
            {
                CreateTopping(i, menu.transform);
            }
            */

            //Bank���̏����Q�Ƃ�����@(WebGL�p)
            for (int i = 0; i < bank.toppingDetails.Length; i++)
            {
                CreateTopping(i, menu.transform);
            }
        }

        //���Topping�𐶐�����֐�
        void CreateTopping(int cardID, Transform place)
        {
            ToppingController topping = Instantiate(toppingPrefab, place).GetComponent<ToppingController>();
            topping.Init(cardID);
        }
    }
}
