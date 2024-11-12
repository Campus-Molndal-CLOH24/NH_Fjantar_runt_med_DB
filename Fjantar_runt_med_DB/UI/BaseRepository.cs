using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.UI
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
            var connection = new SQLiteConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}