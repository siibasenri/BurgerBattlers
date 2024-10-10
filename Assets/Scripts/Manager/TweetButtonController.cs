using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Battle;
using UnityEngine.EventSystems;
using DG.Tweening;

namespace BurgerBattler.Manager
{
    public class TweetButtonController : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] RuleBook ruleBook;
        public void OnClick()
        {
            if (ruleBook.isPlayerTurn)
            {
                StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot(
                    ruleBook.playerTurnCount+ "�^�[���ŏ����I" +
                    "�����~�J�[�h�Q�[���~�n���o�[�K�[�I�u�o�[�K�[�o�g���[�v��V�񂾂�I\n"+ 
                    "https://unityroom.com/games/burgerbattler"));
                //naichilab.UnityRoomTweet.Tweet("burgerbattler", ruleBook.turnCount+ "�^�[���ŏ����I\n" +"�����~�J�[�h�Q�[���~�n���o�[�K�[�I�u�o�[�K�[�o�g���[�v��V�񂾂�I\n", "BurgerBattel");
            }
            else
            {
                StartCoroutine(TweetWithScreenShot.TweetManager.TweetWithScreenShot(
                    ruleBook.enemyTurnCount + "�^�[���Ŕs�k�c\n" +
                    "�����~�J�[�h�Q�[���~�n���o�[�K�[�I�u�o�[�K�[�o�g���[�v��V�񂾂�I\n" 
                    + "https://unityroom.com/games/burgerbattler"));
                //naichilab.UnityRoomTweet.Tweet("burgerbattler", ruleBook.turnCount+"�^�[���Ŕs�k�c\n" +"�����~�J�[�h�Q�[���~�n���o�[�K�[�I�u�o�[�K�[�o�g���[�v��V�񂾂�I\n", "BurgerBattel");
            }
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1), 0.2f);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            transform.DOScale(new Vector3(1f, 1f, 1), 0.1f);
        }

    }
}
