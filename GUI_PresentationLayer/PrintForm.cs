using BLL_BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_PresentationLayer
{
    public partial class PrintForm : Form
    {
        private ReportBLL reportBLL = new ReportBLL();
        private DataTable currentInvoiceData;
        public PrintForm()
        {
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            cbOrders.DataSource = reportBLL.GetAllOrdersList();
            cbOrders.DisplayMember = "OrderDisplay";
            cbOrders.ValueMember = "OrderID";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (cbOrders.SelectedValue != null)
            {
                int orderId = Convert.ToInt32(cbOrders.SelectedValue);
                currentInvoiceData = reportBLL.GetOrderInvoice(orderId);

                // This opens a window showing what the printed page will look like
                printPreviewDialog1.ShowDialog();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (currentInvoiceData == null || currentInvoiceData.Rows.Count == 0) return;

            // Setup Fonts
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 12, FontStyle.Regular);

            int yPos = 50; // Starting vertical position
            int leftMargin = 50; // Starting horizontal position

            // 1. Draw Header
            DataRow firstRow = currentInvoiceData.Rows[0];
            e.Graphics.DrawString("ORDER RECEIPT", titleFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;
            e.Graphics.DrawString("Order ID: " + firstRow["OrderID"].ToString(), regularFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            e.Graphics.DrawString("Date: " + Convert.ToDateTime(firstRow["OrderDate"]).ToShortDateString(), regularFont, Brushes.Black, leftMargin, yPos);
            yPos += 25;
            e.Graphics.DrawString("Agent: " + firstRow["AgentName"].ToString(), regularFont, Brushes.Black, leftMargin, yPos);
            yPos += 40;

            // 2. Draw Table Headers
            e.Graphics.DrawString("Item", headerFont, Brushes.Black, leftMargin, yPos);
            e.Graphics.DrawString("Qty", headerFont, Brushes.Black, leftMargin + 300, yPos);
            e.Graphics.DrawString("Price", headerFont, Brushes.Black, leftMargin + 400, yPos);
            e.Graphics.DrawString("Subtotal", headerFont, Brushes.Black, leftMargin + 500, yPos);
            yPos += 30;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + 600, yPos); // Separator Line
            yPos += 10;

            // 3. Draw Items and Calculate Grand Total
            decimal grandTotal = 0;
            foreach (DataRow row in currentInvoiceData.Rows)
            {
                string itemName = row["ItemName"].ToString();
                string qty = row["Quantity"].ToString();
                decimal price = Convert.ToDecimal(row["UnitAmount"]);
                decimal subtotal = Convert.ToDecimal(row["SubTotal"]);

                e.Graphics.DrawString(itemName, regularFont, Brushes.Black, leftMargin, yPos);
                e.Graphics.DrawString(qty, regularFont, Brushes.Black, leftMargin + 300, yPos);
                e.Graphics.DrawString("$" + price.ToString("0.00"), regularFont, Brushes.Black, leftMargin + 400, yPos);
                e.Graphics.DrawString("$" + subtotal.ToString("0.00"), regularFont, Brushes.Black, leftMargin + 500, yPos);

                grandTotal += subtotal;
                yPos += 25;
            }

            // 4. Draw Grand Total
            yPos += 20;
            e.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + 600, yPos); // Separator Line
            yPos += 20;
            e.Graphics.DrawString("GRAND TOTAL: $" + grandTotal.ToString("0.00"), titleFont, Brushes.Black, leftMargin + 300, yPos);
        }

        private void cbOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
