using Npgsql;
using System;
using System.Windows.Forms;

namespace Lev_ZooShop
{
    public partial class RegistrationForm : Form
    {
        PostgresConnector bd = new PostgresConnector();

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void buttonRegistration_Click(object sender, EventArgs e)
        {
            string login = textBoxLog.Text;
            string password = textBoxPass.Text;
            string telephone = maskedTextBoxTelephone.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(telephone))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            bd.openConnection();
            string updateQuryString = "INSERT INTO users (login, password, telephone) VALUES (@login, @password, @telephone)";
            NpgsqlCommand cmd = new NpgsqlCommand(updateQuryString, bd.getConnection());
            cmd.Parameters.AddWithValue("login", login);
            cmd.Parameters.AddWithValue("password", password);
            cmd.Parameters.AddWithValue("telephone", telephone);
            cmd.ExecuteNonQuery();
            bd.closeConnection();
            MessageBox.Show("Регистрация прошла успешно!");

            this.Hide();
            LoginForm f1 = new LoginForm();
            f1.ShowDialog();
        }

        private void labelBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm f1 = new MainForm();
            f1.ShowDialog();
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}