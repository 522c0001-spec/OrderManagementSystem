using System;
using System.Data;
using DAL_DataAccess;

namespace BLL_BusinessLogic
{
    public class AgentBLL
    {
        private AgentDAL agentDAL = new AgentDAL();

        public DataTable GetAgents()
        {
            return agentDAL.GetAllAgents();
        }

        public bool AddNewAgent(string agentName, string address)
        {
            // Business Rule: Agent name cannot be empty
            if (string.IsNullOrWhiteSpace(agentName))
            {
                return false;
            }

            return agentDAL.AddAgent(agentName, address);
        }
    }
}