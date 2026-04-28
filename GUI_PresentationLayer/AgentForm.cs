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
    public partial class AgentForm : Form
    {
        private AgentBLL agentBLL = new AgentBLL();
        public AgentForm()
        {
            InitializeComponent();
        }

        private void AgentForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            dgvAgents.DataSource = agentBLL.GetAgents();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAddAgent_Click(object sender, EventArgs e)
        {
            string name = txtAgentName.Text;
            string address = txtAddress.Text;

            bool success = agentBLL.AddNewAgent(name, address);

            if (success)
            {
                MessageBox.Show("Agent added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshGrid(); // Update the grid to show the new agent

                // Clear the textboxes
                txtAgentName.Clear();
                txtAddress.Clear();
            }
            else
            {
                MessageBox.Show("Failed to add agent. Please ensure the agent name is not empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

