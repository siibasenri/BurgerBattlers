using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace BurgerBattler.Chara
{
    //�L�����N�^�[�𐶐�����N���X   
    public class CharaSpawn :MonoBehaviour
    {
        [SerializeField] GameObject place, charaPrefab;�@//�����ꏊ�ƃL�����N�^�[�̃v���n�u
        [SerializeField] CharaBank bank; //�L�����N�^�[�ꗗ�����N���X

        //�S�ẴL�����N�^�[�𐶐�����֐�
        public void AllCharaCreate()
        {
            /*
             * �t�H���_���̏����Q�Ƃ��Đ��������@(WebGL�ł͕s��)
            DirectoryInfo dir = new DirectoryInfo("Assets/Resources/CharaEntityList");
            FileInfo[] info = dir.GetFiles("*.asset");
            for (int i = 0; i < info.Length; i++)
            {
                CreateChara(i, place.transform);
            }
            */

            //bank���琶�������@(WebGL�p)
            for (int i = 0; i < bank.charaDetails.Length; i++)
            {
                CreateChara(i, place.transform);
            }

        }

        //�w�肵���L�����𐶐�����֐�
        void CreateChara(int cardID, Transform place)
        {
            CharaController chara = Instantiate(charaPrefab, place).GetComponent<CharaController>();
            chara.Init(cardID);
        }
    }
}
