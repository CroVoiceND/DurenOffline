using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace DurenOffline
{
    public partial class Settings : Form
    {
        Info info = Game.info;
        int wins, loses, draws;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            this.myName.Text = info.myName;
            if (info.numberCards == 36) radioButton1.Checked = true;
            else radioButton2.Checked = true;
            if (info.setMoney > 10 && info.setMoney < 10000) this.myMoneySet.Value = info.setMoney;
            else if (info.allMoney == 0) this.myMoneySet.Value = 0;
            else this.myMoneySet.Value = 10;
            this.wins = info.countWins;
            this.loses = info.countLoses;
            this.draws = info.countDraws;
            this.label4.Text = "Ваші гроші = " + info.allMoney;
            this.WinLose.Text = $"Переміг: {this.wins} разів. Програв: {this.loses} разів.";
            this.Draw.Text = $"Зіграв в нічию: {this.draws} разів";
        }
        /// <summary>
        /// Підтвердження змін параметрів гри
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void agree_Click(object sender, EventArgs e)
        {
            info.myName = myName.Text;
            if (radioButton1.Checked) info.numberCards = 36;
            else info.numberCards = 52;
            if ((info.allMoney) < 10)
            {
                MessageBox.Show("Вам було нараховано " + (10 - info.allMoney) + "грн. із бюджету ХАІ!");
                info.allMoney += (10 - info.allMoney);
            }
            info.countDraws = this.draws;
            info.countLoses = this.loses;
            info.countWins = this.wins;
            if ((int)myMoneySet.Value <= info.allMoney)
                info.setMoney = (int)myMoneySet.Value;
            else
            {
                info.setMoney = info.allMoney;
                myMoneySet.Value = info.allMoney;
            }
            this.Hide();
        }
        /// <summary>
        /// Збереження даних профілю в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "JSON Files (*.json)|*.json|All Files (*.*)|*.*";
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    DataContractJsonSerializer jsFormatter = new DataContractJsonSerializer(typeof(PlayerData));
                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        PlayerData data = new PlayerData(this.myName.Text, info.allMoney, this.wins, this.loses, this.draws);
                        jsFormatter.WriteObject(fs, data);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не вдалося зберегти файл!", "Помилка :(");
            }
        }
        /// <summary>
        /// Зчитування даних профілю із файлу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open_Click(object sender, EventArgs e)
        {
            try
            { 
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Filter = "JSON files (*.json)|*.json";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = dialog.FileName;
                        DataContractJsonSerializer jsFormatter = new DataContractJsonSerializer(typeof(PlayerData));
                        using (FileStream fs = new FileStream(filePath, FileMode.Open))
                        {
                            PlayerData data = (PlayerData)jsFormatter.ReadObject(fs);
                            this.myName.Text = data.Name;
                            this.wins = data.Wins;
                            this.loses = data.Losses;
                            this.draws = data.Draws;
                            info.allMoney = data.Money;
                            this.label4.Text = "Ваші гроші = " + data.Money;
                            this.WinLose.Text = $"Переміг: {this.wins} разів. Програв: {this.loses} разів.";
                            this.Draw.Text = $"Зіграв в нічию: {this.draws} разів";
                        }
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Не вдалося відкрити файл!", "Помилка :(");
            }
        }
    }
    [DataContract]
    class PlayerData
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Money { get; set; }
        [DataMember]
        public int Wins { get; set; }
        [DataMember]
        public int Losses { get; set; }
        [DataMember]
        public int Draws { get; set; }

        public PlayerData(string name, int money, int wins, int losses, int draws)
        {
            Name = name;
            Money = money;
            Wins = wins;
            Losses = losses;
            Draws = draws;
        }
        public PlayerData () { }
    }
}
