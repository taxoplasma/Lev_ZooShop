using System;
using System.Windows.Forms;

namespace Lev_ZooShop
{
    public partial class ItemPanel : UserControl
    {
        private int id { get; set; }
        private string name { get; set; }
        private string quantity { get; set; }
        private string price { get; set; }
        private string description { get; set; }
        private ItemsForm itemsForm;

        public ItemPanel(int id, string name, string quantity, string price, string description, ItemsForm itemsForm)
        {
            InitializeComponent();

            this.id = id;
            this.name = name;
            this.quantity = quantity;
            this.price = price;
            this.description = description;
            this.itemsForm = itemsForm;

            labelName.Text = name;
            labelQuantity.Text = quantity;
            labelPrice.Text = price;
            labelDescription.Text = description;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            itemsForm.AddItemToCart(id, name, decimal.Parse(price), 1);
            itemsForm.UpdateCartInfo();
        }
    }
}