using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Lev_ZooShop
{
    public partial class ItemsForm : Form
    {
        private List<CartItem> cartItems = new List<CartItem>();
        private decimal cartTotal = 0;

        PostgresConnector db = new PostgresConnector();

        public ItemsForm()
        {
            InitializeComponent();
            UpdateCartInfo();
        }

        private void buttnDogs_Click(object sender, EventArgs e)
        {
            showItems(1);
        }

        private void buttonCats_Click(object sender, EventArgs e)
        {
            showItems(2);
        }

        private void buttonRodents_Click(object sender, EventArgs e)
        {
            showItems(3);
        }

        private void buttonReptiles_Click(object sender, EventArgs e)
        {
            showItems(4);
        }

        private void buttonFishes_Click(object sender, EventArgs e)
        {
            showItems(5);
        }

        private void showItems(int category)
        {
            flowLayoutPanelItems.Controls.Clear();
            flowLayoutPanelItems.Controls.AddRange(db.GetItemPanels(category, this).ToArray());
        }

        private void buttonReg_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm f1 = new RegistrationForm();
            f1.ShowDialog();
        }

        private void buttonBasket_Click(object sender, EventArgs e)
        {
            CartForm cartForm = new CartForm(cartItems);
            cartForm.ShowDialog();

            UpdateCartInfo();
            this.Close();
        }

        public void AddItemToCart(int id, string name, decimal price, int quantity)
        {
            var existingItem = cartItems.FirstOrDefault(item => item.Id == id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                var newItem = new CartItem
                {
                    Id = id,
                    Name = name,
                    Price = price,
                    Quantity = quantity
                };
                cartItems.Add(newItem);
            }

            cartTotal += price * quantity;
        }

        public void UpdateCartInfo()
        {
            labeltemsInBasket.Text = $"Товаров в корзине: {cartItems.Sum(item => item.Quantity)}";
            labelPriceBasket.Text = $"Стоимость корзины: {cartTotal} руб.";
        }

        private void ItemsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}