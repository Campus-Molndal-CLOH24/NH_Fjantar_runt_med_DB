using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.UI
{
    using Fjantar_runt_med_DB.DatabaseConnections;

    internal class Menu
    {
        internal static void MenuChoices()
        {
            DatabaseType dbType = default;
            bool validChoice = false;

            while (!validChoice)
            {
                Console.WriteLine("Choose a database type:");
                Console.WriteLine("1. MySQL");
                Console.WriteLine("2. SQLite");
                Console.WriteLine("3. MongoDB");
                Console.WriteLine("4. API");
                Console.WriteLine("5. Exit\n");

                Console.WriteLine("Enter your choice:");
                string? menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        dbType = DatabaseType.MySQL;
                        validChoice = true;
                        Console.WriteLine("You chose MySQL.");
                        break;
                    case "2":
                        dbType = DatabaseType.SQLite;
                        validChoice = true;
                        Console.WriteLine("You chose SQLite.");
                        break;
                    case "3":
                        dbType = DatabaseType.MongoDB;
                        validChoice = true;
                        Console.WriteLine("You chose MongoDB.");
                        break;
                    case "4":
                        dbType = DatabaseType.API;
                        validChoice = true;
                        Console.WriteLine("You chose API.");
                        break;
                    case "5":
                        Program.ApplicationShutdown();
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }

            // Now that we have a valid dbType, we can safely create the DatabaseManager
            var dbManager = new DatabaseManager(dbType);
            Console.WriteLine($"Connected to {dbType}.");
        }
    }
}
