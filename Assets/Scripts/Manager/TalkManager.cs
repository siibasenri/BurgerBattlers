using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

namespace BurgerBattler.Manager
{
    public class TalkManager : MonoBehaviour
    {
        TextMeshProUGUI text; 
        EventTrigger trigger;
        EventTrigger.Entry skipEntry;

        int nowVisableChara, talkLength; //現在の表示可能数と、表示する文字の長さ
        bool isTalkFinished; //文字を全て表示したか
        float delayTime;     //次の文字を表示するまでの時間

        public bool isClose;

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
