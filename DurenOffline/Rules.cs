using System;
using System.Windows.Forms;

namespace DurenOffline
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
        }

        private void Rules_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox2.BorderStyle = BorderStyle.None;
            richTextBox3.BorderStyle = BorderStyle.None;
        }
    }
}
