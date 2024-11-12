using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.UI
{
    internal class Menu
    {
        internal static void MenuChoices()
        {
            Console.WriteLine("Choose a database type:");
            Console.WriteLine("1. MySQL");
            Console.WriteLine("2. SQLite");
            Console.WriteLine("3. MongoDB");
            Console.WriteLine("4. API");
            Console.WriteLine("5. Exit\n");

            Console.WriteLine("Enter your choice:");

            string? menuInput = Console.ReadLine();
            DatabaseType dbType;

            switch (menuInput)
            {
                case "1":
                    dbType = DatabaseType.MySQL;
                    Console.WriteLine("You chose MySQL.");
                    break;
                case "2":
                    dbType = DatabaseType.SQLite;
                    Console.WriteLine("You chose SQLite.");
                    break;
                case "3":
                    dbType = DatabaseType.MongoDB;
                    Console.WriteLine("You chose MongoDB.");
                    break;
                case "4":
                    dbType = DatabaseType.API;
                    Console.WriteLine("You chose API yada yada-something");
                    break;
                case "5":
                    Program.ApplicationShutdown();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    MenuChoices();
                    break;
            }

            // Create a single instance of DatabaseManager with the selected DatabaseType
            var dbManager = new DatabaseManager(dbType);
            Console.WriteLine($"Connected to {dbType}.");
        }
    }
}
