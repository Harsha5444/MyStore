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

        //public static void colourRed(string text)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;
        //    Console.Write(text);
        //    Console.ResetColor();
        //}
        //public static void colourGreen(string text)
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Console.Write(text);
        //    Console.ResetColor();
        //}
        //public static void colourCyan(string text)
        //{
        //    Console.ForegroundColor = ConsoleColor.Cyan;
        //    Console.Write(text);
        //    Console.ResetColor();
        //}

        //public static void colourYellow(string text)
        //{
        //    Console.ForegroundColor = ConsoleColor.DarkYellow;
        //    Console.Write(text);
        //    Console.ResetColor();
        //}
        //public static void colourBlue(string text)
        //{
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.Write(text);
        //    Console.ResetColor();
        public static string GetColoredText(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
            return text;
        }

        public static string colourRed(string text) => GetColoredText(text, ConsoleColor.Red);

        public static string colourGreen(string text) => GetColoredText(text, ConsoleColor.Green);

        public static string colourCyan(string text) => GetColoredText(text, ConsoleColor.Cyan);

        public static string colourYellow(string text) => GetColoredText(text, ConsoleColor.DarkYellow);

        public static string colourBlue(string text) => GetColoredText(text, ConsoleColor.Blue);

    }
}

