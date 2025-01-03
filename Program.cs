﻿using System;
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
            int attempts = 0; 
            while (attempts < 2)
            {
                if (login.VerifyUser()) 
                {
                    DisplayProductList productList = new DisplayProductList(conn);
                    productList.ShowProductList();
                    shop.Menu();
                    break; 
                }
                else
                {
                    attempts++; 
                    if (attempts == 1)
                    {
                        Console.Clear();
                        design.colourRed("Login failed. Please try again.\n\n");
                    }
                    else
                    {
                        design.colourRed("\nLogin failed. Too many attempts. Exiting program.\n");
                    }
                }
            }
            Console.Read(); 
        }
    }
}
