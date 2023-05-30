using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DurenOffline
{
    public partial class GamesTable : Form
    {
        private int elapsedSeconds;

        public GamesTable()
        {
            InitializeComponent();
        }

        internal static Game game = new Game();
        Info info = Game.info;
        
        List<Card> myField = new List<Card>();
        List<Card> hisField = new List<Card>();
        public int numberOfCards;
        internal static List<Player> players = new List<Player>();
        Card firstCardInHand, lastCardInHand;

        private void GamesTable_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;

            loadData();
            game.startGame();
            paintCards();

            string imageFile = "D:\\Projects\\WF\\DurakOffline\\DurakOffline\\AllCards\\";
            trump.Image = info.trumpCard.Image;
            deck.Image = Image.FromFile(imageFile + "0_90.jpg");

            this.firstCardInHand = players[0].Hand[0];
            this.lastCardInHand = players[0].Hand[5];

            
            timer1.Enabled = true;
        }

        /// <summary>
        /// Завантаження даних про ігру
        /// </summary>
        void loadData()
        {
            if (info.myName != null) this.myName.Text = info.myName;
            else this.myName.Text = "Я";
            if (info.numberCards == 36 || info.numberCards == 52) this.numberOfCards = info.numberCards;
            else this.numberOfCards = 36;
            if (info.setMoney >= 10 && info.setMoney <= 10000) this.money.Text = info.setMoney.ToString();
            else this.money.Text = "10";
        }
        /// <summary>
        /// Визначаємо дії комп'ютера
        /// </summary>
        public void hisAction()
        {
            if (!info.isMyStep)
            {
                Card hisJuniorCard = players[1].defineCardForAction(this.allCardOnTable());

                if (hisJuniorCard != null) // Якщо він знайшов карту, щоб зробити крок
                {
                    players[1].Hand.Remove(hisJuniorCard);
                    if (!info.isMyAttack) info.setAttackCard(hisJuniorCard);
                    this.addHisCard(hisJuniorCard);
                    this.paintCards();
                    if (!info.isMyStep) info.toggleStep();
                }
                else // Якщо ні, то заюирає карти зі столу до себе в руки
                {
                    this.myField.Clear();
                    this.hisField.Clear();
                    this.addPlayersCards(players[0].Hand, players[1].Hand);
                    this.paintCards();
                    if (!info.isGetCard)
                    {
                        info.toggleStep();
                        info.toggleAttack();
                    }
                    else
                    {
                        info.setIsGetCard(false);
                    }
                }
            }
        }

        /// <summary>
        /// Завантаження усіх зображень карт у вікні
        /// </summary>
        internal void paintCards()
        {
            if (info.deckCards.Count == 0) deck.Image = null;

            List<PictureBox> myListCards = new List<PictureBox> { myCard1, myCard2, myCard3, myCard4, myCard5, myCard6, myCard7 };
            List<PictureBox> hisListCards = new List<PictureBox> { hisCard1, hisCard2, hisCard3, hisCard4, hisCard5, hisCard6, hisCard7 };
            List<PictureBox> myLCards = new List<PictureBox> { m1, m2, m3, m4, m5, m6 };
            List<PictureBox> hisLCards = new List<PictureBox> { h1, h2, h3, h4, h5, h6 };
            int index = players[0].Hand.IndexOf(firstCardInHand);
            if (index == -1) index = 0;
            foreach (PictureBox p in myListCards) // Зображення карт в руці користувача
            {
                p.Image = null;
                if (index < players[0].Hand.Count)
                {
                    p.Image = players[0].Hand[index].Image;
                    p.Tag = players[0].Hand[index];
                    this.lastCardInHand = players[0].Hand[index];
                    index++;
                }
            }
            if (players[0].Hand.Count > 7) this.firstCardInHand = myCard1.Tag as Card;
            else  if (players[0].Hand.Count != 0) this.firstCardInHand = players[0].Hand[0];
            index = 0;
            foreach (PictureBox p in hisListCards) // Зображення рубашки карт в руці супротивника
            {
                p.Image = null;
                if (index < players[1].Hand.Count)
                {
                    p.Image = Image.FromFile("D:\\Projects\\WF\\DurakOffline\\DurakOffline\\AllCards\\0.jpg");
                    index++;
                }
            }
            index = 0;
            foreach (PictureBox p in myLCards) // Зображення карт користувача на полі бою
            {
                p.Image = null;
                if (index < this.myField.Count)
                {
                    p.Image = this.myField[index].Image;
                    index++;
                }
            }
            index = 0;
            if (!info.isMyAttack && info.attackCard != null && (info.deckCards.Count == 40 || info.deckCards.Count == 24) && !hisField.Contains(info.attackCard)) hisField.Add(info.attackCard);
            foreach (PictureBox p in hisLCards) // Зображення карт комп'ютера на полі бою
            {
                p.Image = null;
                if (index < this.hisField.Count)
                {
                    p.Image = hisField[index].Image;
                    index++;
                }
            }   
            printLeftCountDeck(); 
            if (!info.isMyAttack && info.attackCard != null && hisField.Count <= 1) h1.Image = info.attackCard.Image;
        }
        /// <summary>
        /// Якщо користувач забираю карти зі столу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!info.isMyAttack)
            {
                foreach (Card card in this.myField)
                {
                    players[0].Hand.Add(card);
                }
                foreach (Card card in this.hisField)
                {
                    players[0].Hand.Add(card);
                }
                this.myField.Clear();
                this.hisField.Clear();
                this.addPlayersCards(players[0].Hand, players[1].Hand);
                this.paintCards();
                if (!info.isGetCard)
                {
                    info.toggleStep();
                    info.toggleAttack();
                }
                else
                {
                    info.setIsGetCard(false);
                }
                if (info.isMyStep) info.toggleStep();
                if (info.isMyAttack) info.toggleAttack();
            }
            this.hisAction();
            if (info.deckCards.Count == 0 && players[1].Hand.Count == 0)
            {
                timer1.Enabled = false;
                info.endGaming(players[0].Hand.Count, players[1].Hand.Count);
            }
        }
        /// <summary>
        /// Якщо комп'ютер відбив усі карти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (info.isMyAttack && this.myField.Count == this.hisField.Count)
            {
                this.myField.Clear();
                this.hisField.Clear();
                this.addPlayersCards(players[0].Hand, players[1].Hand);
                this.paintCards();
                if (!info.isGetCard)
                {
                    info.toggleStep();
                    info.toggleAttack();
                }
                else
                {
                    info.setIsGetCard(false);
                }
                if (info.isMyStep) info.toggleStep();
                if (info.isMyAttack) info.toggleAttack();
            }
            this.hisAction();
        }
        /// <summary>
        /// Повернення списку карт на полі бою
        /// </summary>
        /// <returns></returns>
        internal List<Card> allCardOnTable()
        {
            List<Card> cards = new List<Card>();
            if (this.hisField != null) cards.AddRange(this.hisField);
            if (this.myField != null) cards.AddRange(this.myField);
            this.paintCards();
            return cards;
        }
        /// <summary>
        /// Розача карт для гравців
        /// </summary>
        /// <param name="my"></param>
        /// <param name="his"></param>
        internal void addPlayersCards(List<Card> my, List<Card> his)
        {
            int needMy = 6 - my.Count;
            int needHis = 6 - his.Count;

            if (info.isMyAttack)
            {
                players[0].addCard(game.reduceCards(needMy > 0 ? needMy : 0));
                players[1].addCard(game.reduceCards(needHis > 0 ? needHis : 0));
            }
            else
            {
                players[1].addCard(game.reduceCards(needHis > 0 ? needHis : 0));
                players[0].addCard(game.reduceCards(needMy > 0 ? needMy : 0));
            }

            if (info.deckCards.Count == 1)
            {
                this.deck.Image = null;
                this.deck.SendToBack();
            }
            else if (info.deckCards.Count == 0)
            {
                this.deck.Image = null;
                this.trump.Image = null;
            }

            this.paintCards();
        }
        /// <summary>
        /// Визначаємо, чий перший хід
        /// </summary>
        /// <param name="myCards"></param>
        /// <param name="hisCards"></param>
        internal void defineStep(List<Card> myCards, List<Card> hisCards)
        {
            int myJuniorTrumpRank = game.defineJuniorTrumpCard(myCards);
            int hisJuniorTrumpRank = game.defineJuniorTrumpCard(hisCards);

            if (myJuniorTrumpRank != 0)
            {
                if ((myJuniorTrumpRank < hisJuniorTrumpRank) || hisJuniorTrumpRank == 0) // Якщо козирь користувача менший за комп'ютера
                {
                    info.isMyStep = true;
                    info.isMyAttack = true;
                    this.hisAction();
                }
                else // Якщо козирь комп'ютера менший за користувача
                {
                    info.isMyStep = false;
                    info.isMyAttack = false;
                    this.hisAction();
                }
            }
            else // Якщо у користувача немає козиря
            {
                info.isMyStep = false;
                info.isMyAttack = false;
                this.hisAction();
            }

            this.paintCards();
        }
        /// <summary>
        /// Кнопка "ліворуч" для відображення карт, що не поміщаються в руці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftSlide_Click(object sender, EventArgs e)
        {
            if (players[0].Hand.Count > 7)
            {
                int firstIndex = players[0].Hand.IndexOf(this.firstCardInHand);
                List<Card> newList = new List<Card>();
                Again:
                if (firstIndex - 8 >= 0)
                    newList = players[0].Hand.GetRange(firstIndex - 7, 7);
                else
                {
                    firstIndex++;
                    goto Again;
                }
                this.firstCardInHand = newList[0];
                this.lastCardInHand = newList[6];
                paintCards();
            }
        }
        /// <summary>
        /// Кнопка "праворуч" для відображення карт, що не поміщаються в руці
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightSlide_Click(object sender, EventArgs e)
        {
            if (players[0].Hand.Count > 7)
            {
                int lastIndex = players[0].Hand.IndexOf(this.lastCardInHand);
                List<Card> newList = new List<Card>();
                Again:
                if (lastIndex + 8 <= players[0].Hand.Count)
                    newList = players[0].Hand.GetRange(lastIndex + 1, 7);
                else
                {
                    lastIndex--;
                    goto Again;
                }
                this.firstCardInHand = newList[0];
                this.lastCardInHand = newList[6];
                paintCards();
            }
        }
        /// <summary>
        /// Виведення кількості карт, що залишилися в колоді
        /// </summary>
        public void printLeftCountDeck()
        {
            if (info.deckCards.Count > 0)
                leftDeckCount.Text = "Залишилося: " + info.deckCards.Count;
            else
                leftDeckCount.Text = "";
        }
        /// <summary>
        /// Винесення вибраної користувачем карти на поле
        /// </summary>
        /// <param name="card"></param>
        internal void addMyCard(Card card)
        {
            this.myField.Add(card);
            this.paintCards();
            info.toggleStep();
        }
        /// <summary>
        /// Винесення вибраної комп'ютером карти на поле
        /// </summary>
        /// <param name="card"></param>
        internal void addHisCard(Card card)
        {
            this.hisField.Add(card);
            this.paintCards();
            info.toggleStep();
        }
        /// <summary>
        /// Обработчик події натиску на карту в руці користувачем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void myCard1_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            if (info.isMyStep && pictureBox.Image != null)
            {
                Card myStepCard = game.checkMyStep(pictureBox.Tag as Card, this.allCardOnTable());
                if (myStepCard != null)
                {
                    this.addMyCard(myStepCard);
                    if (info.isMyStep) info.toggleStep();
                    players[0].Hand.Remove(myStepCard);
                    paintCards();
                }
            }
            if (!info.isMyStep) this.hisAction();
            if (info.deckCards.Count == 0 && (players[0].Hand.Count == 0 || players[1].Hand.Count == 0))
            {
                timer1.Enabled = false;
                info.endGaming(players[0].Hand.Count, players[1].Hand.Count);
            }
        }
        private void myCard2_Click(object sender, EventArgs e)
        {
            myCard1_Click(sender, e);
        }
        private void myCard3_Click(object sender, EventArgs e)
        {
            myCard1_Click(sender, e);
        }
        private void myCard4_Click(object sender, EventArgs e)
        {
            myCard1_Click(sender, e);
        }
        private void myCard5_Click(object sender, EventArgs e)
        {
            myCard1_Click(sender, e);
        }
        private void myCard6_Click(object sender, EventArgs e)
        {
            myCard1_Click(sender, e);
        }
        private void myCard7_Click(object sender, EventArgs e)
        {
            myCard1_Click(sender, e);
        }
        /// <summary>
        /// Оновлення таймеру кожної секунди
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.elapsedSeconds++;

            int minutes = (this.elapsedSeconds % 3600) / 60; 
            int seconds = (this.elapsedSeconds % 3600) % 60; 

            string formattedTime = $"{minutes:D2}:{seconds:D2}"; 

            labelTimer.Text = formattedTime; 
        }
        private void deck_Click(object sender, EventArgs e)
        {

        }
    }
}
