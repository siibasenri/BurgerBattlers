using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace BurgerBattler.Manager
{
    //説明や解説の文の表示を管理するクラス
    public class TalkManager : MonoBehaviour
    {
        TextMeshProUGUI text; 
        EventTrigger trigger;
        EventTrigger.Entry skipEntry;

        int nowVisableChara, talkLength; //現在の表示可能数と、表示する文字の長さ
        bool isTalkFinished; //文字を全て表示したか
        float delayTime;     //次の文字を表示するまでの時間

        public bool isClose;

        //文字を一文字ずつ表示する関数
        public IEnumerator TalkText(string content)
        {
            InitSetting();
            text.maxVisibleCharacters = 0;
            talkLength = content.Length;

            text.SetText(content);

            var delay = new WaitForSeconds(delayTime);

            for (nowVisableChara = 0; nowVisableChara < content.Length; nowVisableChara++)
            {
                yield return delay;
                text.maxVisibleCharacters = nowVisableChara + 1;
            }
            isTalkFinished = true;
        }

        //クリックしたら全文一気に表示
        //もう一度クリックしたら非表示にする
        public void SkipTalk()
        {
            if (!isTalkFinished)
            {
                nowVisableChara = talkLength;
            }
            else
            {
                isClose = true;
                trigger.triggers.Remove(skipEntry);
                text.SetText("");
                gameObject.SetActive(false);
            }

        }

        //初期化
        void InitSetting()
        {
            text = GetComponentInChildren<TextMeshProUGUI>();
            trigger = GetComponent<EventTrigger>();

            isTalkFinished = false;
            isClose = false;
            nowVisableChara = 0;
            delayTime = 0.07f;

            skipEntry = new EventTrigger.Entry();
            skipEntry.eventID = EventTriggerType.PointerClick;
            skipEntry.callback.AddListener((eventDate) => { SkipTalk(); });

            trigger.triggers.Add(skipEntry);
        }
    }
}
