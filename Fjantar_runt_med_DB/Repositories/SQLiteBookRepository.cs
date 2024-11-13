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
            using var connection = await GetOpenConnectionAsync();
            // SQL query to insert a new record into the Books table using parameterized queries
            string sql = "INSERT INTO Books (Title, Author) VALUES (@Title, @Author);";
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Author", entity.Author);

            // Execute the query asynchronously
            await command.ExecuteNonQueryAsync();
        }


        public async Task UpdateAsync(Books entity)
        {
            using var connection = await GetOpenConnectionAsync();
            string sql = "UPDATE Books SET Title = @Title, Author = @Author WHERE Id = @Id;";
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Title", entity.Title);
            command.Parameters.AddWithValue("@Author", entity.Author);
            command.Parameters.AddWithValue("@Id", entity.Id);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = await GetOpenConnectionAsync();
            string sql = "DELETE FROM Books WHERE Id = @Id;";
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@Id", id);

            await command.ExecuteNonQueryAsync();
        }
        public async Task<List<Books>> ReadAllAsync()
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
    }
}
