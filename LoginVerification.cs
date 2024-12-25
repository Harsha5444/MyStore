using System;
using System.Data.SqlClient;

namespace MyStore
{
    class LoginVerification
    {
        private SqlConnection conn;
        private UserManagement userManagement;
        public LoginVerification(SqlConnection connection)
        {
            conn = connection;
            userManagement = new UserManagement(conn);
        }
        public bool VerifyUser()
        {
            design.colourCyan("Welcome To MyStore.com\n");
            design.colourCyan("\nDo you have login credentials? (Yes/No): ");
            string input = Console.ReadLine().ToLower();

            if (input == "yes")
            {
                return userManagement.UserValidate();
            }
            else if (input == "no")
            {
                design.colourGreen("\n--------------User Registration--------------\n");
                return userManagement.RegisterUser();
            }
            else
            {
                design.colourRed("\nInvalid input. Please enter 'Yes' or 'No'.");
                return false;
            }
        }
    }
}
