using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BurgerBattler.Manager
{
    //解説テキストを表示するクラス
    public class ExplainButton : MonoBehaviour
    {
        [SerializeField] TalkManager talkManager;

        //キャラ選択を解説するテキスト
        public void CharaExplain()
        {
            talkManager.gameObject.SetActive(true);
            StartCoroutine(talkManager.TalkText("ここでは使用するキャラクターを選択します。" +
                 "\nそれぞれのキャラクターが能力を持っており、バトルを有利にします。"));
        }

        //バーガー作成を解説するテキスト
        public void CreateExplain()
        {
            talkManager.gameObject.SetActive(true);
            StartCoroutine(talkManager.TalkText("ここでは自分のハンバーガーを作成します。\n" +
                "ハンバーガーの「？」をクリックすると、右欄にトッピング一覧が出ます。" +
                "好みのトッピングを選択してください。\n" +
                "上段・中断・下段それぞれにトッピングを選び、ハンバーガーを完成させてください。"));
        }

        //戦闘を解説するテキスト
        public void BattleExplain()
        {
            talkManager.gameObject.SetActive(true);
            StartCoroutine(talkManager.TalkText("対戦相手とのバトルです。相手のハンバーガーを当てれば勝ちです。\n" +
                "<color=yellow>カード</color>を出すか<color=yellow>コール</color>をすると、次のプレイヤーのターンに移ります。\n" +
                "<color=yellow>カード</color>を場に出すと試合が有利になります。なお、カードは補充されません。\n" +
                "<color=yellow>左下のベル</color>で、対戦相手のハンバーガーをコールできます。" +
                "位置とトッピングが1つ合っていたら1イートとなり、3イートで勝利となります。"));
        }

          
    }
}
