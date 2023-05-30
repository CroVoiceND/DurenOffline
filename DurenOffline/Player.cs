using System.Collections.Generic;
using System.Windows.Forms;

namespace DurenOffline
{
    internal class Player
    {
        public string Name { get; set; }
        public List<Card> Hand = new List<Card>();
        Info info = Game.info;

        /// <summary>
        /// Додавання карт до руки гравця
        /// </summary>
        /// <param name="cards"></param>
        public void addCard(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                this.Hand.Add(card);
            }
        }

        /// <summary>
        /// Видалення карт із руки гравця
        /// </summary>
        /// <param name="id"></param>
        public void reduceCard(int id)
        {
            for (int i = 0; i < this.Hand.Count; i++)
            {
                if (id == this.Hand[i].Id)
                    this.Hand.Remove(Hand[i]);
            }
        }

        /// <summary>
        /// Визначення молодшої карти гравця
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public Card defineJuniorCard(List<Card> cards)
        {
            Card minCard = cards[0];
            foreach (Card card in cards)
            {
                if (card.Id < minCard.Id)
                    minCard = card;
            }
            return minCard;
        }

        /// <summary>
        /// Перевірка на коректність атаки користувача
        /// </summary>
        /// <param name="card"></param>
        /// <param name="battleCards"></param>
        /// <returns></returns>
        public Card myAttack(Card card, List<Card> battleCards)
        {
            if (battleCards.Count == 0)
            {
                info.setAttackCard(card);
                this.reduceCard(card.Id);
                info.toggleStep();
                return card;
            }
            foreach (Card c in battleCards)
            {
                if (c.CardRank == card.CardRank)
                {
                    info.setAttackCard(card);
                    this.reduceCard(card.Id);
                    info.toggleStep();
                    return card;
                }
            }
            MessageBox.Show("Подібної карти немає на столі!", "Помилка!");
            return null;
        }

        /// <summary>
        /// Перевірка на коректність оборони користувача
        /// </summary>
        /// <param name="defenseCard"></param>
        /// <param name="attackCard"></param>
        /// <returns></returns>
        public Card myDefense(Card defenseCard, Card attackCard)
        {
            if (attackCard != null && defenseCard != null)
            {
                if ((defenseCard.CardSuit == attackCard.CardSuit && (int)defenseCard.CardRank > (int)attackCard.CardRank) || (defenseCard.CardSuit == info.trumpCard.CardSuit && attackCard.CardSuit != info.trumpCard.CardSuit))
                {
                    this.reduceCard(defenseCard.Id);
                    info.toggleStep();
                    return defenseCard;
                }
                MessageBox.Show("Цією картою не можна відбитися!", "Помилка!");
                return null;
            }
            return null;
        }

        /// <summary>
        /// Визначення дій для комп'ютера
        /// </summary>
        /// <param name="battleCards"></param>
        /// <returns></returns>
        public Card defineCardForAction(List<Card> battleCards)
        {
            if (info.isMyAttack)
                return this.defineCardForDefense(info.attackCard, battleCards);

            return this.defineCardForAttack(battleCards);
        }

        /// <summary>
        /// Визначення, чи є карта для підкидання з руки комп'ютера
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public Card defineJuniorExistCard(List<Card> cards)
        {
            List<Card> existCards = new List<Card>();
            foreach (Card card in this.Hand)
            {
                if (card.CardRank == cards[0].CardRank)
                    existCards.Add(card);
            }
            return existCards.Count > 0 ? this.defineJuniorCard(existCards) : null;
        }

        /// <summary>
        /// Перевірка на коректність атаки комп'ютера
        /// </summary>
        /// <param name="battleCards"></param>
        /// <returns></returns>
        public Card defineCardForAttack(List<Card> battleCards)
        {
            if (this.Hand.Count > 0)
            {
                Card attackCard;
                if (battleCards.Count == 0)
                {
                    List<Card> notTrumpCards = new List<Card>();
                    foreach (Card card in this.Hand)
                    {
                        if (card.CardSuit != info.trumpCard.CardSuit)
                            notTrumpCards.Add(card);
                    }
                    List<Card> trumpCards = new List<Card>();
                    foreach (Card card in this.Hand)
                    {
                        if (card.CardSuit == info.trumpCard.CardSuit)
                            trumpCards.Add(card);
                    }

                    if (notTrumpCards.Count > 0)
                        attackCard = defineJuniorCard(notTrumpCards);
                    else
                        attackCard = defineJuniorCard(trumpCards);

                    info.setAttackCard(attackCard);
                    return attackCard;
                }
                attackCard = this.defineJuniorExistCard(battleCards);
                info.setAttackCard(attackCard);
                return attackCard;
            }
            return null;
        }
        
        /// <summary>
        /// Перевірка на коректність оборони комп'ютера
        /// </summary>
        /// <param name="attackCard"></param>
        /// <param name="battleCards"></param>
        /// <returns></returns>
        public Card defineCardForDefense(Card attackCard, List<Card> battleCards)
        {
            if (attackCard != null)
            {
                List<Card> defenseCards = new List<Card>();
                foreach (Card card in this.Hand)
                {
                    if (card.CardSuit == attackCard.CardSuit && (int)card.CardRank > (int)attackCard.CardRank)
                        defenseCards.Add(card);
                }

                List<Card> trumpCards = new List<Card>();
                foreach (Card card in this.Hand)
                {
                    if (card.CardSuit == info.trumpCard.CardSuit)
                        trumpCards.Add(card);
                }

                if (defenseCards.Count > 0)
                    return this.defineJuniorCard(defenseCards);

                if (attackCard.CardSuit != info.trumpCard.CardSuit && trumpCards.Count > 0)
                    return this.defineJuniorCard(trumpCards);

                this.addCard(battleCards);
                info.toggleStep();
                info.setIsGetCard(true);
            }
            return null;
        }

        public Player(string name)
        {
            Name = name;
        }

        public Player() { }
    }
}