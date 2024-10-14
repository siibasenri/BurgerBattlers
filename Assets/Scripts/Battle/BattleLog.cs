using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Topping;
using BurgerBattler.Manager;
using BurgerBattler.Card;

namespace BurgerBattler.Battle
{
    //�g�p�����J�[�h�Ƃ���œ������������X�N���v�g
    public class BattleLog : MonoBehaviour
    {
        List<string> pow, nat, hea, removes;          //��ޕʃg�b�s���O�̃��X�g�ƁA���O���X�g
        int powCount, natCount, heaCount, doubleShot; //��ޕʃg�b�s���O�̐��ƁA����Ă�H�ސ�, unknowns;
        bool isPow, isNat, isHea;                     //�e�큛����`���g�p�������ۂ�
        string snipe;                                 //�X�i�C�p�[�Ŕ��������g�b�s���O�̖��O
        
        private void Start()
        {
            //unknowns = 3;
            doubleShot = -1;
            snipe = "";

            isPow = false;
            isNat = false;
            isHea = false;

            powCount = -1;
            natCount = -1;
            heaCount = -1;

            removes = new List<string>();
            pow = new List<string>() { "�p�e�B", "�x�[�R��" };
            nat = new List<string>() { "�ʎq", "�`�[�Y" };
            hea = new List<string>() { "�g�}�g", "�L���x�c" };

        }

        //�g�p�����J�[�h���L�^
        //�J�[�h�̎�ށA�J�E���g(������`�̏ꍇ�Ɏg�p)�A�g�b�s���O��
        public void WriteLog(CardKind kind, int count, string topping)
        {
            switch (kind)
            {
                case CardKind.isPow:
                    if (!isPow)
                    {
                        powCount = count;

                        if(powCount == 0)
                        {
                            removes.AddRange(pow);
                        }
                        isPow = true;
                    }
                    break;

                case CardKind.isHea:
                    if (!isHea)
                    {
                        heaCount = count;

                        if (heaCount == 0)
                        {
                            removes.AddRange(hea);
                        }
                        isHea = true;
                    }
                    break;

                case CardKind.isNat:
                    if (!isNat)
                    {
                        natCount = count;

                        if (natCount == 0)
                        {
                            removes.AddRange(nat);
                        }
                        isNat = true;
                    }
                    break;

                case CardKind.Sniper:

                    snipe = topping;

                    break;

                case CardKind.DoubleShot:

                    doubleShot = count;

                    break;

                case CardKind.isNotIn:

                    removes.Add(topping);

                    break;

            }

        }

        //���O��ǂݎ��
        public (List<string>,int,int,int,int,string) ReadLog()
        {
            return (removes, powCount, natCount, heaCount, doubleShot, snipe);
        }


    }
}
