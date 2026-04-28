using System;
using System.Data;
using DAL_DataAccess;

namespace BLL_BusinessLogic
{
    public class ItemBLL
    {
        private ItemDAL itemDAL = new ItemDAL();

        public DataTable GetItems()
        {
            return itemDAL.GetAllItems();
        }

        public bool AddNewItem(string itemName, string size, decimal price)
        {
            // Business Rule: Item name cannot be empty and price must be greater than 0
            if (string.IsNullOrWhiteSpace(itemName) || price <= 0)
            {
                return false;
            }

            return itemDAL.AddItem(itemName, size, price);
        }
    }
}