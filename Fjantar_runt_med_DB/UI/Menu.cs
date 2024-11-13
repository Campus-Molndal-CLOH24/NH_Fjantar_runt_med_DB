using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.UI
{
    using Fjantar_runt_med_DB.Core;
    using Fjantar_runt_med_DB.DatabaseConnections;
    using Fjantar_runt_med_DB.Repositories;
    using Fjantar_runt_med_DB.SQLiteEntities;

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
                string menuInput = Console.ReadLine() ?? string.Empty;

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

            // Call ConnectionHandling with the chosen database type
            ConnectionHandling(dbType).GetAwaiter().GetResult(); // Call async method synchronously
        }

        internal static async Task ShowCrudMenu(ICrudRepository<Books> repository)
        {
            bool exitCRUDMenu = false;

            while (!exitCRUDMenu)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Read");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Back to Main Menu\n");

                string choice = Console.ReadLine() ?? string.Empty;

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Creating...");
                        // Example: await repository.CreateAsync(new Books { Title = "Sample", Author = "Author" });
                        break;
                    case "2":
                        Console.WriteLine("Reading all books...");
                        var books = await repository.ReadAllAsync();

                        if (books.Count > 0)
                        {
                            foreach (var book in books)
                            {
                                Console.WriteLine($"Id: {book.Id}, Title: {book.Title}, Author: {book.Author}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No books found.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Updating...");
                        // Example: await repository.UpdateAsync(new Books { Id = 1, Title = "Updated Title", Author = "Updated Author" });
                        break;
                    case "4":
                        Console.WriteLine("Deleting...");
                        // Example: await repository.DeleteAsync(1);
                        break;
                    case "5":
                        exitCRUDMenu = true; // Exit the loop to return to the main menu
                        Console.WriteLine("Returning to the main menu...");
                        MenuChoices();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        internal static async Task ConnectionHandling(DatabaseType dbType)
        {
            var dbManager = new DatabaseManager(dbType);

            switch (dbType)
            {
                case DatabaseType.SQLite:
                    var sqliteRepository = new SQLiteBookRepository(dbManager.ConnectionString);
                    await ShowCrudMenu(sqliteRepository); // Show CRUD menu for SQLite
                    break;

                case DatabaseType.MySQL:
                    Console.WriteLine($"Connected to {dbType}.");
                    // Future: Initialize MySQL repository and call CRUD menu if needed
                    break;

                case DatabaseType.MongoDB:
                    Console.WriteLine($"Connected to {dbType}.");
                    // Future: Initialize MongoDB repository and call CRUD menu if needed
                    break;

                case DatabaseType.API:
                    Console.WriteLine($"Connected to {dbType}.");
                    // Future: Initialize API handler and call appropriate methods if needed
                    break;

                default:
                    Console.WriteLine("Unsupported database type.");
                    break;
            }
        }
    }
}
