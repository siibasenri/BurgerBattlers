using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BurgerBattler.Card;
using BurgerBattler.Player;

namespace BurgerBattler.Card
{
    //�J�[�h�����p�X�N���v�g
    public class CardSpawn : MonoBehaviour
    {
        [SerializeField] GameObject cardPrefab,hand;
        [SerializeField] DeckList deckList;
        [SerializeField] PlayerInfo player;
        
        //�f�b�L�̃J�[�h�S�Ă𐶐�����
        public IEnumerator AllCardCreate()
        {
            deckList.AddCharaCard(player);

            for (int i = 0; i < deckList.cards.Count; i++)
            {
                CreateCard(deckList.cards[i], hand.transform);
                yield return new WaitForSeconds(1f);
            }
        }

        //ID�Ɉ�v����J�[�h�𐶐�����
        void CreateCard(int cardID, Transform place)
        {
            CardController card = Instantiate(cardPrefab, place).GetComponent<CardController>();
            card.Init(cardID,player.isPayer);
        }

    }
}
