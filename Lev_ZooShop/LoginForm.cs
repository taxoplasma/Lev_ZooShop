using Npgsql;
using System;
using System.Windows.Forms;

namespace Lev_ZooShop
{
    public partial class LoginForm : Form
    {
        PostgresConnector bd = new PostgresConnector();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLog.Text;
            string password = textBoxPass.Text;

            NpgsqlCommand cmd_ex = new NpgsqlCommand($"SELECT COUNT(*) FROM users " +
                $"WHERE login = '{login}' and " +
                $"password = '{password}'", bd.getConnection());

            bd.openConnection();

            int user = Convert.ToInt32(cmd_ex.ExecuteScalar());

            bd.closeConnection();

            if (user > 0)
            {
                this.Hide();
                ItemsForm f1 = new ItemsForm();
                f1.ShowDialog();
            }
            else MessageBox.Show("Неправильно введён логин или пароль.");
        }

        private void labelRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm f2 = new MainForm();
            f2.ShowDialog();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}