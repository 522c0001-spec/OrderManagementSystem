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
    public partial class FilterForm : Form
    {
        private ReportBLL reportBLL = new ReportBLL();
        private AgentBLL agentBLL = new AgentBLL(); // To load the combobox
        public FilterForm()
        {
            InitializeComponent();
        }
        private void FilterForm_Load(object sender, EventArgs e)
        {
            // Populate the dropdown with agents when the form opens
            cbAgents.DataSource = agentBLL.GetAgents();
            cbAgents.DisplayMember = "AgentName";
            cbAgents.ValueMember = "AgentID";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBestItems_Click(object sender, EventArgs e)
        {
            // Fetch and display the top selling items
            dgvReports.DataSource = reportBLL.GetBestSellingItems();
        }

        private void btnCustomerPurchases_Click(object sender, EventArgs e)
        {
            // Ensure an agent is selected
            if (cbAgents.SelectedValue != null)
            {
                int agentId = Convert.ToInt32(cbAgents.SelectedValue);
                // Fetch and display that specific agent's purchases
                dgvReports.DataSource = reportBLL.GetPurchasesByCustomer(agentId);
            }
        }
    }
}
