using System;
using System.Data;
using DAL_DataAccess;

namespace BLL_BusinessLogic
{
    public class OrderBLL
    {
        private OrderDAL orderDAL = new OrderDAL();

        // Takes the AgentID and a DataTable representing the shopping cart from the GUI
        public bool PlaceOrder(int agentId, DataTable cart)
        {
            // Business Rule: Don't process empty orders
            if (cart == null || cart.Rows.Count == 0)
            {
                return false;
            }

            // Step 1: Create the parent Order in the database
            int newOrderId = orderDAL.CreateOrder(agentId, DateTime.Now);

            if (newOrderId <= 0) return false; // Fail safe if the order didn't generate an ID

            // Step 2: Loop through every row in the cart and save it to OrderDetails
            foreach (DataRow row in cart.Rows)
            {
                int itemId = Convert.ToInt32(row["ItemID"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal unitAmount = Convert.ToDecimal(row["Price"]); // We will grab the unit price

                orderDAL.CreateOrderDetail(newOrderId, itemId, quantity, unitAmount);
            }

            return true;
        }
    }
}