using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using BurgerBattler.Card;
using BurgerBattler.Chara;
using BurgerBattler.Topping;
using BurgerBattler.Battle;
using System.IO;
using DG.Tweening;

namespace BurgerBattler.Player
{
    //�ΐ푊��ł���AI�̍s���𑀍삷��N���X
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] PlayerInfo enemyInfo;
        [SerializeField] RuleBook ruleBook;
        [SerializeField] GameObject spellPanel;
        [SerializeField] CharaBank charaBank;
        [SerializeField] ToppingBank toppingBank;
        [SerializeField] BattleLog log;

        GameObject hand;

        /*
        List<string> pow;
        List<string> nat;
        List<string> hel;
        List<string> Toppings;
        */

        private void Start()
        {
            hand = enemyInfo.hand;
        }

        //�����_���ɃL������I��
        public void RandomCharaSelect()
        {

            int charaIndex = UnityEngine.Random.Range(0, charaBank.charaDetails.Length);

            enemyInfo.playerCharactor = new CharaModel(charaIndex);
        }

        //�����_���Ƀg�b�s���O��I��
        public void RandomAllToppingSelect()
        {
            int TopID = UnityEngine.Random.Range(0, toppingBank.toppingDetails.Length);
            int MidID = UnityEngine.Random.Range(0, toppingBank.toppingDetails.Length);
            int BotID = UnityEngine.Random.Range(0, toppingBank.toppingDetails.Length);

            enemyInfo.top = new ToppingModel(TopID);
            enemyInfo.mid = new ToppingModel(MidID);
            enemyInfo.bot = new ToppingModel(BotID);


            enemyInfo.burger[0] = enemyInfo.top;
            enemyInfo.burger[1] = enemyInfo.mid;
            enemyInfo.burger[2] = enemyInfo.bot;

            //Debug.Log(enemyInfo.top.nameText + " : " + enemyInfo.mid.nameText + " : " + enemyInfo.bot.nameText);
        }


        //�ΐ�ŁA�R�[�����J�[�h���g�����������_���ɑI��
        public IEnumerator RandomAction()
        {
            yield return new WaitForSeconds(2);
            int coin = UnityEngine.Random.Range(0, 2);

            if (coin == 0 && hand.transform.childCount != 0)
            {
                StartCoroutine(PlayRandomCard());
                //StartCoroutine(PlayDeepCard());
            }
            else
            {
                //RandomCall();
                NormalCall(log.ReadLog());
            }
        }

        //�����_���ȃJ�[�h���g��
        IEnumerator PlayRandomCard()
        {
            CardController[] cards = hand.GetComponentsInChildren<CardController>();
            int randomIndex = UnityEngine.Random.Range(0, cards.Length);
            GameObject randomCard = cards[randomIndex].gameObject;

            randomCard.GetComponent<CardController>().view.Reverse();
            randomCard.transform.DOMove(spellPanel.transform.position, 1).SetEase(Ease.OutQuart);
            randomCard.transform.rotation = Quaternion.Euler(Vector2.zero);
            randomCard.transform.DOScale(Vector2.one * 1.2f, 1).SetEase(Ease.InOutQuart);

            yield return StartCoroutine(ruleBook.UseCard(cards[randomIndex].model.kind));
            yield return new WaitForSeconds(1f);
            Destroy(randomCard);

        }
        IEnumerator PlayDeepCard()
        {
            int cardID = 0;
            CardController[] cards = hand.GetComponentsInChildren<CardController>();
            for (int i = 0; i < cards.Length; i++)
            {
                if (cards[i].model.kind == CardKind.isPow)
                {
                    cardID = i;
                }
            }
            GameObject choiceCard = cards[cardID].gameObject;

            choiceCard.GetComponent<CardController>().view.Reverse();
            choiceCard.transform.DOMove(spellPanel.transform.position, 1).SetEase(Ease.OutQuart);
            choiceCard.transform.rotation = Quaternion.Euler(Vector2.zero);
            choiceCard.transform.DOScale(Vector2.one * 1.2f, 1).SetEase(Ease.InOutQuart);

            yield return StartCoroutine(ruleBook.UseCard(CardKind.isHea));
            yield return new WaitForSeconds(1f);
            Destroy(choiceCard);
        }

        //�����_���ȃg�b�s���O��I��ŃR�[������
        void RandomCall()
        {

            ToppingModel[] call = new ToppingModel[3];

            int TopID = UnityEngine.Random.Range(0, toppingBank.toppingDetails.Length);
            int MidID = UnityEngine.Random.Range(0, toppingBank.toppingDetails.Length);
            int BotID = UnityEngine.Random.Range(0, toppingBank.toppingDetails.Length);

            call[0] = new ToppingModel(TopID);
            call[1] = new ToppingModel(MidID);
            call[2] = new ToppingModel(BotID);



            StartCoroutine(ruleBook.Call(call));
        }

        //������`�ƃA�����M�[�̏�񂾂��Ő���(��`���A�����M�[���Ȃ��ꍇ������)
        void NormalCall((List<string> removes, int powCount, int natCount, int heaCount, int doubleshot, string snipe) p)
        {
            ToppingModel[] call = new ToppingModel[3];
            int unknowns = 3;

            List<string> allToppings = new List<string>()
            {
                "�g�}�g",
                "�L���x�c",
                "�`�[�Y",
                "�ʎq",
                "�x�[�R��",
                "�p�e�B"
            };

            List<string> powList = new List<string>() { "�p�e�B", "�x�[�R��" };
            List<string> natList = new List<string>() { "�ʎq", "�`�[�Y" };
            List<string> heaList = new List<string>() { "�g�}�g", "�L���x�c" };

            //�A�����M�[���`��0���o�Ă��ꍇ�A�m��Ŏg���ĂȂ��̂ŁAremoves�ŏ���
            powList.RemoveAll(item => p.removes.Contains(item));
            natList.RemoveAll(item => p.removes.Contains(item));
            heaList.RemoveAll(item => p.removes.Contains(item));

            /*
            Debug.Log("plist:" + powList.Count);
            Debug.Log("nlist:" + natList.Count);
            Debug.Log("hlist:" + heaList.Count);
            */

            //�������̂��߂̃g�b�s���O�ꗗ���X�g
            List<string> initList = new List<string>();
            initList.AddRange(powList);
            initList.AddRange(natList);
            initList.AddRange(heaList);

            List<ToppingModel> tmpList = new List<ToppingModel>();

            //�p���t����`��1�ȏオ�o���ꍇ�AtmpList�Ƀ����_���ȃp���t���H�ނ�����B
            //initList(�I���\�ȃg�b�s���O�̃��X�g)����p���t���n������(�p���t���n�͂�������ȏ�I���ł��Ȃ�����)
            if (p.powCount > 0)
            {

                for (int i = 0; i < p.powCount; i++)
                {
                    string randomTopping = powList[UnityEngine.Random.Range(0, powList.Count)];
                    int randomID = allToppings.IndexOf(randomTopping);
                    ToppingModel tmp = new ToppingModel(randomID);
                    tmpList.Add(tmp);
                    unknowns--;
                    //Debug.Log("p:"+tmp.nameText);
                }
                initList.RemoveAll(item => powList.Contains(item));
            }

            //�i�`��������`�ł����l
            if (p.natCount > 0)
            {

                for (int i = 0; i < p.natCount; i++)
                {
                    string randomTopping = natList[UnityEngine.Random.Range(0, natList.Count)];
                    int randomID = allToppings.IndexOf(randomTopping);
                    ToppingModel tmp = new ToppingModel(randomID);
                    tmpList.Add(tmp);
                    unknowns--;
                    //Debug.Log("n:" + tmp.nameText);
                }
                initList.RemoveAll(item => natList.Contains(item));
            }

            //�w���V�[��`�ł����l
            if (p.heaCount > 0)
            {

                for (int i = 0; i < p.heaCount; i++)
                {
                    string randomTopping = heaList[UnityEngine.Random.Range(0, heaList.Count)];
                    int randomID = allToppings.IndexOf(randomTopping);
                    ToppingModel tmp = new ToppingModel(randomID);
                    tmpList.Add(tmp);
                    unknowns--;
                    //Debug.Log("h:" + tmp.nameText);
                }
                initList.RemoveAll(item => heaList.Contains(item));
            }

            //�܂��s���ȋ�ނ̐������A�����_���ȃg�b�s���O��I��
            //������`�����łɑI�΂�Ă��炻�ꂩ��͑I�΂Ȃ�(initList����폜�ς�)
            if (unknowns > 0)
            {
                for (int i = 0; i < unknowns; i++)
                {
                    string randomTopping = initList[UnityEngine.Random.Range(0, initList.Count)];
                    int randomID = allToppings.IndexOf(randomTopping);
                    ToppingModel tmp = new ToppingModel(randomID);
                    tmpList.Add(tmp);
                    //unknowns--;
                    //Debug.Log("u:" + tmp.nameText);
                }
            }

            //���3�������_���ɓ���ւ���B
            for (int i = 0; i < 3; i++)
            {
                ToppingModel tmp = tmpList[UnityEngine.Random.Range(0, tmpList.Count)];
                call[i] = tmp;
                tmpList.Remove(tmp);
            }

            StartCoroutine(ruleBook.Call(call));
        }



        void DeepCall((List<string> removes, int powCount, int natCount, int heaCount, int doubleshot, string snipe) p)
        {
            int unknowns = 3;
            ToppingModel snipeTopping;
            ToppingModel[] call = new ToppingModel[3];
            List<string> allToppings = new List<string>()
                {
                    "�g�}�g",
                    "�L���x�c",
                    "�`�[�Y",
                    "�ʎq",
                    "�x�[�R��",
                    "�p�e�B"
                };

            List<string> powList = new List<string>() { "�p�e�B", "�x�[�R��" };
            List<string> natList = new List<string>() { "�ʎq", "�`�[�Y" };
            List<string> heaList = new List<string>() { "�g�}�g", "�L���x�c" };


        }
    }
}
