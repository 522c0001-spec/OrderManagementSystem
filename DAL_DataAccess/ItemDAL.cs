using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_DataAccess
{
    public class ItemDAL
    {
        private DBConnection dbConnection = new DBConnection();

        // Method to fetch all items to display in the grid
        public DataTable GetAllItems()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Item";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Method to add a new item to the database
        public bool AddItem(string itemName, string size, decimal price)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "INSERT INTO Item (ItemName, Size, Price) VALUES (@Name, @Size, @Price)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", itemName);
                cmd.Parameters.AddWithValue("@Size", size);
                cmd.Parameters.AddWithValue("@Price", price);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0; // Returns true if the insert was successful
            }
        }
    }
}