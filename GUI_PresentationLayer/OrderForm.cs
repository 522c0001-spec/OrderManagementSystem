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
    public partial class OrderForm : Form
    {
        private AgentBLL agentBLL = new AgentBLL();
        private ItemBLL itemBLL = new ItemBLL();
        private OrderBLL orderBLL = new OrderBLL();

        private DataTable cartTable;
        public OrderForm()
        {
            InitializeComponent();
            InitializeCart();
        }
        private void InitializeCart()
        {
            cartTable = new DataTable();
            cartTable.Columns.Add("ItemID", typeof(int));
            cartTable.Columns.Add("ItemName", typeof(string));
            cartTable.Columns.Add("Quantity", typeof(int));
            cartTable.Columns.Add("Price", typeof(decimal)); // Unit price
            cartTable.Columns.Add("Total", typeof(decimal)); // Qty * Price

            dgvCart.DataSource = cartTable;
        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            // Load Agents into the ComboBox
            cbAgents.DataSource = agentBLL.GetAgents();
            cbAgents.DisplayMember = "AgentName";
            cbAgents.ValueMember = "AgentID";

            // Load Items into the ComboBox
            cbItems.DataSource = itemBLL.GetItems();
            cbItems.DisplayMember = "ItemName";
            cbItems.ValueMember = "ItemID";
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            // Ensure an item is actually selected
            if (cbItems.SelectedItem == null) return;

            // Get the selected row data from the ComboBox
            DataRowView selectedItem = (DataRowView)cbItems.SelectedItem;

            int itemId = Convert.ToInt32(selectedItem["ItemID"]);
            string itemName = selectedItem["ItemName"].ToString();
            int quantity = (int)numQuantity.Value;
            decimal price = Convert.ToDecimal(selectedItem["Price"]);
            decimal total = quantity * price;

            // Add it to our shopping cart table
            cartTable.Rows.Add(itemId, itemName, quantity, price, total);

            // Reset quantity to 1 for the next item
            numQuantity.Value = 1;
        }   
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Ensure an agent is selected and the cart isn't empty
            if (cbAgents.SelectedItem == null)
            {
                MessageBox.Show("Please select an Agent first.", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cartTable.Rows.Count == 0)
            {
                MessageBox.Show("Your cart is empty!", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Grab the AgentID
            int agentId = Convert.ToInt32(cbAgents.SelectedValue);

            // Send the AgentID and the whole Cart to the BLL
            bool success = orderBLL.PlaceOrder(agentId, cartTable);

            if (success)
            {
                MessageBox.Show("Order placed successfully! Check your database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cartTable.Clear(); // Empty the cart for the next order
            }
            else
            {
                MessageBox.Show("Failed to place order. Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
