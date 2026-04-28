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
    public partial class ItemForm : Form
    {
        private ItemBLL itemBLL = new ItemBLL();
        public ItemForm()
        {
            InitializeComponent();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            dgvItems.DataSource = itemBLL.GetItems();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string name = txtItemName.Text;
            string size = txtSize.Text;

            // Try to parse the price from text to a decimal
            if (decimal.TryParse(txtPrice.Text, out decimal price))
            {
                bool success = itemBLL.AddNewItem(name, size, price);

                if (success)
                {
                    MessageBox.Show("Item added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid(); // Instantly update the grid to show the new item

                    // Clear the textboxes
                    txtItemName.Clear();
                    txtSize.Clear();
                    txtPrice.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to add item. Please check your inputs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

