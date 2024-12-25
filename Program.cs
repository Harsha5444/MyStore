using System;
using System.Data.SqlClient;
using System.Configuration;

namespace MyStore
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MiniProjectDB"].ConnectionString);
            LoginVerification login = new LoginVerification(conn);
            ShoppingMenu shop = new ShoppingMenu(conn);
            if (login.VerifyUser())
            {
                DisplayProductList productList = new DisplayProductList(conn);
                productList.ShowProductList();
                shop.Menu();
            }
            else
            {
                design.colourRed("\nLogin/Registration failed.\nExiting program.");
            }
        }
    }        
}
