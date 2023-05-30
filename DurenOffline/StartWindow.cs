using System;
using System.Windows.Forms;

namespace DurenOffline
{
    public partial class StartWindow : Form
    { 
        public StartWindow()
        {
            InitializeComponent();
        }
        private void StartWindow_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        /// <summary>
        /// Розпочаток нової гри
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGame_Click(object sender, EventArgs e)
        {
            GamesTable form2 = new GamesTable();
            form2.Show();
        }
        /// <summary>
        /// Відкриття налаштувань гри
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settings_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.ShowDialog();
        }
        /// <summary>
        /// Відкриття правил гри
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rules_Click(object sender, EventArgs e)
        {
            Rules rules = new Rules();
            rules.ShowDialog();
        }
        /// <summary>
        /// Вихід з програми
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
