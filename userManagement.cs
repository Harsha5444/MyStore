using System;
using System.Data;
using System.Data.SqlClient;

namespace MyStore
{
    class UserManagement
    {
        private SqlConnection conn;
        public UserManagement(SqlConnection connection)
        {
            conn = connection;
        }
        public bool UserValidate()
        {
            design.colourYellow("Enter Username: ");
            string username = Console.ReadLine();
            design.colourYellow("Enter Password: ");
            string password = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("[dbo].[UserLogin]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);

            try
            {
                conn.Open();
                int result = (int)cmd.ExecuteScalar(); 
                if (result == 1)
                {
                    design.colourGreen("Login successful.\n");
                    Session.Username = username;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                design.colourRed($"Error: {ex.Message}\n");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
        public bool RegisterUser()
        {
            design.colourYellow("Enter Full Name: ");
            string fullName = Console.ReadLine();
            design.colourYellow("Enter Username: ");
            string username = Console.ReadLine();
            string password = "";
            string confirmPassword = "";
            while (true)
            {
                design.colourYellow("Enter Password: ");
                password = Console.ReadLine();
                design.colourYellow("Confirm Password: ");
                confirmPassword = Console.ReadLine();
                if (password == confirmPassword)
                {
                    break; 
                }
                else
                {
                    design.colourRed("Passwords do not match. Please try again.\n");
                }
            }
            design.colourYellow("Enter Mobile Number: ");
            string mobileNumber = Console.ReadLine();

            SqlCommand cmd = new SqlCommand("[dbo].[RegisterUser]", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@MobileNumber", mobileNumber);

            try
            {
                conn.Open();                
                int result = (int)cmd.ExecuteScalar();
                if (result == 1)
                {
                    design.colourGreen("User registered successfully!\n");
                    Session.Username = username;
                    return true;
                }
                else
                {
                    design.colourRed("\nError: The username already exists. Please choose a different username.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                design.colourRed($"\nAn error occurred: {ex.Message}");
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
