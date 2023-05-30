using System.Collections.Generic;

namespace DurenOffline
{
    internal class Info
    {   
        public bool isMyAttack { get; set; } // Статус, чий зараз хід
        public bool isMyStep { get; set; } // Статус, чий зараз крок
        public bool isGetCard { get; set; } // Статус, чи взяв хтось карту
        public Card attackCard { get; set; } // Атакуюча карта
        public Card trumpCard { get; set; } // Козирна карта
        public int numberCards { get; set; } // Кількість карт у грі
        public string myName { get; set; } // Ім'я користувача
        public int allMoney { get; set; } // Банк користувача
        public int setMoney { get; set; } // Ставка користувача
        public int iWinOrNor { get; set; } // Результат гри
        public int countWins { get; set; } // Кількість перемог
        public int countLoses { get; set; } // Кількість поразок
        public int countDraws { get; set; } // Кількість гри внічию
        public List<Card> deckCards { get; set; } // Колода гри


        public void toggleStep()
        {
            this.isMyStep = !isMyStep;
        }

        public void toggleAttack()
        {
            this.isMyAttack = !isMyAttack;
        }

        public void setIsGetCard(bool isGetCard)
        {
            this.isGetCard = isGetCard;
        }

        public void setAttackCard(Card card)
        {
            this.attackCard = card;
        }

        // Метод, що визначає переможця по закінченню гри
        public void endGaming(int myCount, int hisCount)
        {
            if (myCount == 0 && hisCount != 0)
            {
                this.iWinOrNor = 1;
                this.allMoney += this.setMoney;
                this.countWins++;
            }
            else if (hisCount == 0 && myCount != 0)
            {
                this.iWinOrNor = -1;
                this.allMoney -= this.setMoney;
                this.countLoses++;
            }
            else
            {
                this.iWinOrNor = 0;
                this.countDraws++;
            }
            EndGame end = new EndGame();
            end.ShowDialog();
        }

        public Info(bool isMyAttack, bool isMyStep, bool isGetCard, Card attackCard, Card trumpCard, int numberCards, List<Card> deckCards, string myName, int allMoney, int setMoney)
        {
            this.isMyAttack = isMyAttack;
            this.isMyStep = isMyStep;
            this.isGetCard = isGetCard;
            this.attackCard = attackCard;
            this.trumpCard = trumpCard;
            this.numberCards = numberCards;
            this.deckCards = deckCards;
            this.myName = myName;
            this.allMoney = allMoney;
            this.setMoney = setMoney;
        }
        public Info() { }
    }
}
