using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BurgerBattler.Chara
{
    [CreateAssetMenu(fileName = "CharaEntity", menuName = "Create CharaEntity")]

    //�L�����N�^�[�̃f�[�^��o�^���邽�߂̃N���X(WebGL�ł͎g�p�s��)
    public class CharaEntity : ScriptableObject
    {
        //public int charaID;
        public CharaKind charaKind;
        public string charaName;
        public Sprite charaIcon;
        public string charaExplain;
    }
}
