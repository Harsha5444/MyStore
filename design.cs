using System;
using System.Data.SqlClient;

namespace MyStore
{
    public static class design
    {
        public static void DisplayTable(SqlDataReader reader)
        {
            Console.WriteLine(new string('-', reader.FieldCount * 20));
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.Write(reader.GetName(i).PadRight(20));
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', reader.FieldCount * 20));
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i].ToString().PadRight(20));
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', reader.FieldCount * 20));
        }

        public static void colourRed(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void colourGreen(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void colourCyan(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
