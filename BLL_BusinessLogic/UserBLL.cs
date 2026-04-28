using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_BusinessLogic
{
    public class UserBLL
    {
        public bool VerifyUserLogin(string username, string password)
        {
            // TEMPORARY CODE FOR TESTING THE GUI
            // Later, we will replace this with a call to your DAL_DataAccess to check the SQL database.
            if (username == "admin" && password == "1234")
            {
                return true;
            }

            return false;
        }
    }
}
