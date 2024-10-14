using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Manager
{
    //����e�L�X�g��\������N���X
    public class ExplainButton : MonoBehaviour
    {
        [SerializeField] TalkManager talkManager;

        //�L�����I�����������e�L�X�g
        public void CharaExplain()
        {
            talkManager.gameObject.SetActive(true);
            StartCoroutine(talkManager.TalkText("�����ł͎g�p����L�����N�^�[��I�����܂��B" +
                 "\n���ꂼ��̃L�����N�^�[���\�͂������Ă���A�o�g����L���ɂ��܂��B"));
        }

        //�o�[�K�[�쐬���������e�L�X�g
        public void CreateExplain()
        {
            talkManager.gameObject.SetActive(true);
            StartCoroutine(talkManager.TalkText("�����ł͎����̃n���o�[�K�[���쐬���܂��B\n" +
                "�n���o�[�K�[�́u�H�v���N���b�N����ƁA�E���Ƀg�b�s���O�ꗗ���o�܂��B" +
                "�D�݂̃g�b�s���O��I�����Ă��������B\n" +
                "��i�E���f�E���i���ꂼ��Ƀg�b�s���O��I�сA�n���o�[�K�[�����������Ă��������B"));
        }

        //�퓬���������e�L�X�g
        public void BattleExplain()
        {
            talkManager.gameObject.SetActive(true);
            StartCoroutine(talkManager.TalkText("�ΐ푊��Ƃ̃o�g���ł��B����̃n���o�[�K�[�𓖂Ă�Ώ����ł��B\n" +
                "<color=yellow>�J�[�h</color>���o����<color=yellow>�R�[��</color>������ƁA���̃v���C���[�̃^�[���Ɉڂ�܂��B\n" +
                "<color=yellow>�J�[�h</color>����ɏo���Ǝ������L���ɂȂ�܂��B�Ȃ��A�J�[�h�͕�[����܂���B\n" +
                "<color=yellow>�����̃x��</color>�ŁA�ΐ푊��̃n���o�[�K�[���R�[���ł��܂��B" +
                "�ʒu�ƃg�b�s���O��1�����Ă�����1�C�[�g�ƂȂ�A3�C�[�g�ŏ����ƂȂ�܂��B"));
        }

          
    }
}
