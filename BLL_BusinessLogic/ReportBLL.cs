using System;
using System.Data;
using DAL_DataAccess;

namespace BLL_BusinessLogic
{
    public class ReportBLL
    {
        private ReportDAL reportDAL = new ReportDAL();

        public DataTable GetBestSellingItems()
        {
            return reportDAL.GetBestItems();
        }

        public DataTable GetPurchasesByCustomer(int agentId)
        {
            if (agentId <= 0) return null;
            return reportDAL.GetCustomerPurchases(agentId);
        }
        public DataTable GetAllOrdersList()
        {
            return reportDAL.GetAllOrders();
        }

        public DataTable GetOrderInvoice(int orderId)
        {
            return reportDAL.GetInvoiceData(orderId);
        }
    }
}