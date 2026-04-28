using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL_DataAccess
{
    public class AgentDAL
    {
        private DBConnection dbConnection = new DBConnection();

        // Method to fetch all agents to display in the grid
        public DataTable GetAllAgents()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Agent";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }

        // Method to add a new agent to the database
        public bool AddAgent(string agentName, string address)
        {
            using (SqlConnection conn = dbConnection.GetConnection())
            {
                string query = "INSERT INTO Agent (AgentName, Address) VALUES (@Name, @Address)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", agentName);
                cmd.Parameters.AddWithValue("@Address", address);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result > 0; // Returns true if the insert was successful
            }
        }
    }
}