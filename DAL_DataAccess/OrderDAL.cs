using System;
using System.Data.SqlClient;

namespace DAL_DataAccess
{
    public class OrderDAL
    {
        private DBConnection dbConnection = new DBConnection();

        // 1. Creates the main order and returns the new OrderID
        public int CreateOrder(int agentId, DateTime orderDate)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                // SCOPE_IDENTITY() returns the ID that SQL just auto-generated for us
                string query = "INSERT INTO [Order] (OrderDate, AgentID) VALUES (@Date, @AgentID); SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Date", orderDate);
                cmd.Parameters.AddWithValue("@AgentID", agentId);

                conn.Open();
                int newOrderId = Convert.ToInt32(cmd.ExecuteScalar());
                return newOrderId;
            }
        }

        // 2. Inserts a single item line into the OrderDetail table
        public bool CreateOrderDetail(int orderId, int itemId, int quantity, decimal unitAmount)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "INSERT INTO OrderDetail (OrderID, ItemID, Quantity, UnitAmount) VALUES (@OrderID, @ItemID, @Qty, @Amount)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                cmd.Parameters.AddWithValue("@ItemID", itemId);
                cmd.Parameters.AddWithValue("@Qty", quantity);
                cmd.Parameters.AddWithValue("@Amount", unitAmount);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
        }
    }
}