using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore
{
    class ShoppingMenu
    {
        private SqlConnection conn;
        public ShoppingMenu(SqlConnection connection)
        {
            conn = connection;
        }
        public void Menu()
        {
            int i=0;
            while (i != 4)
            {
                design.colourCyan("\nWhat would you like to do?\n");
                Console.WriteLine("0. Show Product(s) List");
                Console.WriteLine("1. Add to Cart");
                Console.WriteLine("2. View Cart");
                Console.WriteLine("3. Place Order");
                Console.WriteLine("4. Exit");
                Console.Write($"Press any of (0, 1, 2, 3, 4) : ");
                i = Convert.ToInt32(Console.ReadLine());

                switch (i)
                {
                    case 0:
                        Console.Clear();
                        DisplayProductList productList = new DisplayProductList(conn);
                        productList.ShowProductList();
                        break;
                    case 1:
                        Console.Clear();
                        AddToCart();
                        break;
                    case 2:
                        ViewCart();
                        break;
                    case 3:
                        PlaceOrder();
                        break;
                    case 4:
                        design.colourCyan("\nThank you for Visiting MyStore.com. Bye Bye..!");
                        break;
                    default:
                        design.colourRed("\nPlease Choose a Valid Option!!");
                        break;
                }
            }
        }
        public void ViewCart()
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("[dbo].[ViewCart]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Username", Session.Username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    design.colourCyan("\nYour Cart: \n");
                    design.DisplayTable(reader);
                }
                else
                {
                    design.colourRed("\nYour Cart is Empty..! Place a Product to View Cart.\n");
                }
            }
            catch (Exception ex)
            {
                design.colourRed($"Error: {ex.Message}\n");
            }
            finally
            {
                conn.Close();
            }
        }
        public void AddToCart()
        {
            DisplayProductList productList = new DisplayProductList(conn);
            productList.ShowProductList();
            design.colourCyan("Add Product To Cart: \n\n");
            design.colourYellow("Enter ProductID: ");
            int id = Convert.ToInt32(Console.ReadLine());
            design.colourYellow("Enter Quantity: ");
            int q = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("[dbo].[AddToCart]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductId", id);
            cmd.Parameters.AddWithValue("@Username", Session.Username);
            cmd.Parameters.AddWithValue("@Quantity", q);
            try
            {
                conn.Open();
                string resultMessage = (string)cmd.ExecuteScalar();
                design.colourBlue(resultMessage);
            }
            catch (Exception ex)
            {
                design.colourRed($"Error: {ex.Message}\n");
            }
            finally
            {
                conn.Close();
            }
        }
        public void PlaceOrder()
        {
            Console.Clear();
            SqlCommand cmd = new SqlCommand("[dbo].[PlaceOrder]", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@Username", Session.Username);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    string resultMessage = reader["Result"].ToString();
                    if (resultMessage != "Cart is empty. Cannot place an order.")
                    {
                        string orderedProducts = reader["OrderDetails"].ToString();
                        decimal totalCost = Convert.ToDecimal(reader["TotalCost"]);
                        DateTime orderDate = Convert.ToDateTime(reader["OrderDate"]);

                        design.colourGreen("\n" + resultMessage + "\n");
                        design.colourCyan("\nOrder Details:");
                        design.colourGreen($"\nProducts Ordered:".PadRight(20) + orderedProducts);
                        design.colourGreen($"\nTotal Cost:".PadRight(20) + $"${totalCost}");
                        design.colourGreen($"\nOrder Date:".PadRight(20) + orderDate.ToString());

                    }
                    else
                    {
                        design.colourRed("\n" + resultMessage + "\n");
                    }
                }
                else
                {
                    design.colourRed("No order details available. Something went wrong.\n");
                }
            }
            catch (Exception ex)
            {
                design.colourRed($"Error: {ex.Message}\n");
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
