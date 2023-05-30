using System;
using System.Collections.Generic;
using System.Linq;

namespace DurenOffline
{
    internal class Game
    {
        internal List<Player> players = new List<Player>();
        internal static Info info = new Info(true, true, false, null, null, 36, null, "You", 50, 10);
        GamesTable t = new GamesTable();

        // Метод розпочинає нову гру
        public void startGame(bool newGame = true)
        {
            this.createDeck(info.numberCards);
            this.mixDeck();

            List<Card> firstMyCards = new List<Card>();
            List<Card> firstHisCards = new List<Card>();

            firstMyCards = reduceCards(6);
            firstHisCards = reduceCards(6);

            players.Clear();
            players.Add(new Player(info.myName));
            //players[0].Hand.Clear();
            players[0].addCard(firstMyCards);
            players.Add(new Player("Computer 1"));
            //players[1].Hand.Clear();
            players[1].addCard(firstHisCards);
            GamesTable.players = players;

            t.defineStep(firstMyCards, firstHisCards);
        }

        // Генерується колода карт
        public void createDeck(int numberOfCards = 36)
        {
            List<Card> deckCards = new List<Card>();
            int id = 1;
            if (numberOfCards == 52)
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        deckCards.Add(new Card(id, suit, rank, Card.GetCardImage(suit, rank)));
                        id++;
                    }
                }
            }
            else
            {
                id = 17;
                foreach (Rank rank in Enum.GetValues(typeof(Rank)).Cast<Rank>().Skip(4))
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        deckCards.Add(new Card(id, suit, rank, Card.GetCardImage(suit, rank)));
                        id++;
                    }
                }
            }

            info.deckCards = deckCards;
        }

        // Карти перемішуються та визначається козирь гри
        public void mixDeck()
        {
            Random random = new Random();

            for (int i = info.deckCards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Card temp = info.deckCards[i];
                info.deckCards[i] = info.deckCards[j];
                info.deckCards[j] = temp;
            }

            int randomIndex = random.Next(0, info.deckCards.Count);
            info.trumpCard = info.deckCards[randomIndex];
            info.deckCards.Remove(info.trumpCard);
            info.deckCards.Insert(0, info.trumpCard);
        }

        // Роздача потрібної кількості карт
        public List<Card> reduceCards(int countCards)
        {
            List<Card> removedCard = new List<Card>(6);
            if (countCards > info.deckCards.Count) countCards = info.deckCards.Count;
            for (int i = info.deckCards.Count; i > info.deckCards.Count - countCards; i--)
                removedCard.Add(info.deckCards[i - 1]);

            drawDeck(removedCard);
            return removedCard;
        }

        // Видалення списку карт з колоди
        public void drawDeck(List<Card> cards)
        {
            foreach (Card c in cards)
            {
                info.deckCards.Remove(c);
            }
        }

        // Визначення мінімальної козирної карти
        public int defineJuniorTrumpCard(List<Card> cards)
        {
            Suit trumpSuit = info.trumpCard.CardSuit;
            List<Card> del = new List<Card>();
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].CardSuit != trumpSuit)
                    del.Add(cards[i]);
            }
            for (int i = 0; i <  del.Count; i++)
            {
                for (int j = 0; j < cards.Count; j++)
                {
                    if (del[i] == cards[j])
                    {
                        cards.Remove(cards[j]);
                        break;
                    }
                }
            }
            if (cards.Count != 0)
            {
                Card minRankCard = cards.OrderBy(card => card.CardRank).First();
                return (int)minRankCard.CardRank;
            }
            return 0;
        }

        // Перевірка, для чого я вибрав карту - атака чи оборона
        public Card checkMyStep(Card card, List<Card> battleCards)
        {
            if (info.isMyAttack)
                return players[0].myAttack(card, battleCards);

            return players[0].myDefense(card, info.attackCard);
        }
    }
}
