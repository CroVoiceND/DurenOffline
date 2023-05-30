using System.Drawing;

namespace DurenOffline
{
    /// <summary>
    /// Масть карт
    /// </summary>
    public enum Suit { Hearts, Diamonds, Clubs, Spades };
    /// <summary>
    /// Значення карт
    /// </summary>
    public enum Rank { Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King, Ace };
    internal class Card
    {
        /// <summary>
        /// Номер карти
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Масть карти
        /// </summary>
        public Suit CardSuit { get; set; }
        /// <summary>
        /// Значення карти
        /// </summary>
        public Rank CardRank { get; set; }
        /// <summary>
        /// Зображення карти
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Метод, що поверає назву зображення карти 
        /// </summary>
        /// <returns></returns>
        public static Image GetCardImage(Suit suit, Rank rank)
        {
            int nameImg = 0;

            switch (suit)
            {
                case Suit.Hearts:
                    nameImg = 1;
                    break;
                case Suit.Diamonds:
                    nameImg = 2;
                    break;
                case Suit.Clubs:
                    nameImg = 3;
                    break;
                case Suit.Spades:
                    nameImg = 4;
                    break;
            }

            switch (rank)
            {
                case Rank.Two:
                    nameImg += 0;
                    break;
                case Rank.Three:
                    nameImg += 4;
                    break;
                case Rank.Four:
                    nameImg += 8;
                    break;
                case Rank.Five:
                    nameImg += 12;
                    break;
                case Rank.Six:
                    nameImg += 16;
                    break;
                case Rank.Seven:
                    nameImg += 20;
                    break;
                case Rank.Eight:
                    nameImg += 24;
                    break;
                case Rank.Nine:
                    nameImg += 28;
                    break;
                case Rank.Ten:
                    nameImg += 32;
                    break;
                case Rank.Jack:
                    nameImg += 36;
                    break;
                case Rank.Queen:
                    nameImg += 40;
                    break;
                case Rank.King:
                    nameImg += 44;
                    break;
                case Rank.Ace:
                    nameImg += 48;
                    break;
            }

            return Image.FromFile("D:\\Projects\\WF\\DurakOffline\\DurakOffline\\AllCards\\" + nameImg.ToString() + ".jpg");
        }

        public Card(int id, Suit cardSuit, Rank cardRank, Image image)
        {
            Id = id;
            CardSuit = cardSuit;
            CardRank = cardRank;
            Image = image;
        }

        public Card() { }
    }
}
