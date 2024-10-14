using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace BurgerBattler.Chara
{
    //�L�����N�^�[�̌����߂��Ǘ�����N���X
    public class CharaView : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI nameText, explainText;
        [SerializeField] Image iconImage;
        
        //�e�L�X�g��摜��\������
        public void Show(CharaModel charaModel)
        {
            nameText.text = charaModel.name;
            iconImage.sprite = charaModel.icon;
            explainText.text = charaModel.explain;
        }
    }
}
