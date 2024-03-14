using System;
using System.Windows.Forms;

namespace Lev_ZooShop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm f1 = new LoginForm();
            f1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm f2 = new RegistrationForm();
            f2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemsForm f3 = new ItemsForm();
            f3.ShowDialog();
        }
    }
}
