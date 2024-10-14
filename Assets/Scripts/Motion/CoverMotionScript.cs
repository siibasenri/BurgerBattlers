using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BurgerBattler.Motion
{
    //�ΐ펞�����̃o�[�K�[���m�F����Ƃ��̃J�o�[�̓������Ǘ�����N���X
    public class CoverMotionScript : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
    {
        [SerializeField] GameObject dish,burger,cover; //�o�[�K�[���̂��Ă�M�A�쐬�����o�[�K�[�A�J�o�[
        
        //�J�[�\������������J�o�[���グ��
        public void OnPointerEnter(PointerEventData eventData)
        {
           cover.GetComponent<RectTransform>().DOMove(burger.transform.position, 0.1f);
        }

        //�J�[�\�����O�ꂽ�牺����
        public void OnPointerExit(PointerEventData eventData)
        {
           cover.GetComponent<RectTransform>().DOMove(dish.transform.position, 0.1f);
        }
    }
}
