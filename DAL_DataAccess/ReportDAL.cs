using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_DataAccess
{
    public class ReportDAL
    {
        private DBConnection dbConnection = new DBConnection();

        // Query 1: Finds the best-selling items across all orders
        public DataTable GetBestItems()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                // Joins OrderDetail and Item, sums the quantity, and sorts highest to lowest
                string query = @"
                    SELECT i.ItemName, SUM(od.Quantity) AS TotalSold, SUM(od.Quantity * od.UnitAmount) AS TotalRevenue
                    FROM OrderDetail od 
                    JOIN Item i ON od.ItemID = i.ItemID 
                    GROUP BY i.ItemName 
                    ORDER BY TotalSold DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Query 2: Finds all items purchased by a specific customer/agent
        public DataTable GetCustomerPurchases(int agentId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = @"
                    SELECT o.OrderDate, i.ItemName, od.Quantity, od.UnitAmount, (od.Quantity * od.UnitAmount) AS Total
                    FROM [Order] o 
                    JOIN OrderDetail od ON o.OrderID = od.OrderID 
                    JOIN Item i ON od.ItemID = i.ItemID 
                    WHERE o.AgentID = @AgentID
                    ORDER BY o.OrderDate DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@AgentID", agentId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        public DataTable GetAllOrders()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "SELECT OrderID, CONCAT('Order #', OrderID, ' - ', OrderDate) AS OrderDisplay FROM [Order] ORDER BY OrderID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Gets the full invoice details for a specific order
        public DataTable GetInvoiceData(int orderId)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = @"
                    SELECT o.OrderID, o.OrderDate, a.AgentName, i.ItemName, od.Quantity, od.UnitAmount, (od.Quantity * od.UnitAmount) AS SubTotal
                    FROM [Order] o
                    JOIN Agent a ON o.AgentID = a.AgentID
                    JOIN OrderDetail od ON o.OrderID = od.OrderID
                    JOIN Item i ON od.ItemID = i.ItemID
                    WHERE o.OrderID = @OrderID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}