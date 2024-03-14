using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lev_ZooShop
{
    public partial class CartForm : Form
    {
        private List<CartItem> cartItems;

        public CartForm(List<CartItem> cartItems)
        {
            InitializeComponent();
            this.cartItems = cartItems;

            PopulateCartItems();
        }

        private void PopulateCartItems()
        {
            foreach (var cartItem in cartItems)
            {
                ListViewItem item = new ListViewItem(cartItem.Name);
                item.SubItems.Add(cartItem.Quantity.ToString());
                item.SubItems.Add(cartItem.Price.ToString());
                listViewCart.Items.Add(item);
            }
        }

        private void buttonCheckout_Click(object sender, EventArgs e)
        {
            ShowOrderInformation();
        }

        private decimal CalculateCartTotal()
        {
            decimal total = 0;
            foreach (var item in cartItems)
            {
                total += item.Quantity * item.Price;
            }
            return total;
        }

        private void ShowOrderInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Список товаров в корзине:");
            foreach (var item in cartItems)
            {
                sb.AppendLine($"{item.Name} - {item.Quantity} шт. - {item.Price} руб. за шт.");
            }

            decimal cartTotal = CalculateCartTotal();
            sb.AppendLine($"Общая стоимость: {cartTotal} руб.");

            Random rnd = new Random();
            int orderNumber = rnd.Next(1000, 9999);

            sb.AppendLine($"Номер заказа: {orderNumber}");

            string message = sb.ToString();

            if (MessageBox.Show(message, "Информация о заказе", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
            {
                this.Close();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }
    }
}