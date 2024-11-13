using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.Repositories
{
    using System.Data.SQLite;

    // Base class to handle database connections to avoid code duplication

    internal abstract class BaseRepository
    {
        private readonly string _connectionString;

        protected BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected async Task<SQLiteConnection> GetOpenConnectionAsync()
        {
            try
            {
                var connection = new SQLiteConnection(_connectionString);
                await connection.OpenAsync();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening connection: {ex.Message}");
                throw; // Re-throw to let calling methods handle if needed
            }
        }
    }
}