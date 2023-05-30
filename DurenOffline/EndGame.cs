using System;
using System.Drawing;
using System.Windows.Forms;

namespace DurenOffline
{
    public partial class EndGame : Form
    {
        public EndGame()
        {
            InitializeComponent();
        }
        private void EndGame_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;


            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(800, 300);

            Info info = Game.info;
            if (info.iWinOrNor == 1) // Якщо користувач переміг
            {
                richTextBox1.AppendText("Yes, Перемога за тобою!!!\n");
                richTextBox1.AppendText("Твій виграш: " + info.setMoney * 2);
                pictureBox1.Image = Image.FromFile("D:\\Projects\\WF\\Остаточна версія\\DurenOffline\\DurenOffline\\DurenOffline\\Resources\\championship1.png.");
            }
            else if (info.iWinOrNor == -1) // Якщо користувач програв
            {
                richTextBox1.AppendText("Хм, пощастить іншого разу!!!\n");
                richTextBox1.AppendText("Програна ставка - " + info.setMoney);
                pictureBox1.Image = Image.FromFile("D:\\Projects\\WF\\Остаточна версія\\DurenOffline\\champion.png.");
            }
            else // Якщо зіграли внічию
            {
                richTextBox1.AppendText("Ого, це щось неймовірне!!!\n");
                richTextBox1.AppendText("Таке рідко буває, це нічия!");
                pictureBox1.Image = Image.FromFile("D:\\Projects\\WF\\Остаточна версія\\DurenOffline\\draw.png.");
            }

            richTextBox1.SelectAll(); 
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center; 
            richTextBox1.DeselectAll(); 
            richTextBox1.BorderStyle = BorderStyle.None;
        }
        /// <summary>
        /// Закриття всіх вікон окрім головного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form firstForm = Application.OpenForms[0];
            for (int i = 0; i < Application.OpenForms.Count; i++) 
            {
                if (Application.OpenForms[i] != firstForm)
                {
                    Application.OpenForms[i].Close();
                }
            }
        }
    }
}
