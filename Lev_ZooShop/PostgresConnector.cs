using Npgsql;
using System.Collections.Generic;

namespace Lev_ZooShop
{
    class PostgresConnector
    {
        NpgsqlConnection connection = new NpgsqlConnection("Server=localhost; " +
            "Port=5432; " +
            "User Id=postgres; " +
            "Password=8702; " +
            "Database=Lev_ZooShop");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public NpgsqlConnection getConnection()
        {
            return connection;
        }

        public List<ItemPanel> GetItemPanels(int category, ItemsForm itemsForm)
        {
            List<ItemPanel> itemPanels = new List<ItemPanel>();

            openConnection();

            NpgsqlCommand getItems = new NpgsqlCommand($"SELECT * FROM items WHERE category_id = {category}", connection);

            NpgsqlDataReader reader = getItems.ExecuteReader();

            while (reader.Read())
            {
                ItemPanel itemPanel = new ItemPanel(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetDecimal(3).ToString(), reader.GetString(4), itemsForm);

                itemPanels.Add(itemPanel);
            }
            closeConnection();

            return itemPanels;
        }
    }
}