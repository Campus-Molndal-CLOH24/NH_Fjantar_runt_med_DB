using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.Repositories
{
    using Fjantar_runt_med_DB.Core;
    using Fjantar_runt_med_DB.SQLiteEntities;
    using System.Data.SQLite;


    internal class SQLiteBookRepository : BaseRepository, ICrudRepository<Books>
    {
        // Constructor that takes a connection string from the UI layer and passes it to the base class
        public SQLiteBookRepository(string connectionString) : base(connectionString) {}

        public async Task CreateAsync(Books entity)
        {
            try
            {
                using var connection = await GetOpenConnectionAsync();
                string sql = "INSERT INTO Books (Title, Author) VALUES (@Title, @Author);";
                using var command = new SQLiteCommand(sql, connection);
                command.Parameters.AddWithValue("@Title", entity.Title);
                command.Parameters.AddWithValue("@Author", entity.Author);

                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating book: {ex.Message}");
                // Optionally rethrow or handle the error as needed
            }
        }


        public async Task UpdateAsync(Books entity)
        {
            try
            {
            using var connection = await GetOpenConnectionAsync();
            string sql = "UPDATE Books SET Title = @Title, Author = @Author WHERE Id = @Id;";
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Author", entity.Author);
            command.Parameters.AddWithValue("@Id", entity.Id);

            await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating book: {ex.Message}");
                // Optionally rethrow or handle the error as needed
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
            using var connection = await GetOpenConnectionAsync();
            string sql = "DELETE FROM Books WHERE Id = @Id;";
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating book: {ex.Message}");
                // Optionally rethrow or handle the error as needed
            }
        }
        public async Task<List<Books>> ReadAllAsync()
        {
            try
            {
            using var connection = await GetOpenConnectionAsync();
            string sql = "SELECT Id, Title, Author FROM Books;";
            using var command = new SQLiteCommand(sql, connection);

            var books = new List<Books>();

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                books.Add(new Books
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Author = reader.GetString(2)
                });
            }

            return books; // Return the list of books
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating book: {ex.Message}");
                return new List<Books>(); // Return an empty list on error
                // We chose to return an empty list, but you could also rethrow or handle the error as needed
                // Empty list can be preferable in case we want to avoid null, and this is a db-table that can be empty
            }
        }
    }
}
