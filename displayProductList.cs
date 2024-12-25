using System;
using System.Data;
using System.Data.SqlClient;

namespace MyStore
{
    class DisplayProductList
    {
        private SqlConnection conn;

        public DisplayProductList(SqlConnection connection)
        {
            conn = connection;
        }
        public void ShowProductList()
        {
            SqlCommand cmd = new SqlCommand("[dbo].[GetProductList]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                design.colourCyan("\nProduct List: \n");
                design.DisplayTable(reader);
            }
            catch (Exception ex)
            {
                design.colourRed($"Error: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
