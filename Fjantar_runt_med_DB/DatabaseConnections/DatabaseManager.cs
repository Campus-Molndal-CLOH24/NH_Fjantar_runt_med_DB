using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fjantar_runt_med_DB.DatabaseConnections
{
    // Defining enum for database types
    internal enum DatabaseType
    {
        MySQL,
        SQLite,
        MongoDB,
        API
    }

    internal class DatabaseManager
    {
        private readonly string _connectionString;

        public string ConnectionString => _connectionString; // Expose connection string as a property

        public DatabaseManager(DatabaseType dbType)
        {
            // Set the connection string based on the selected database type
            _connectionString = dbType switch
            {
                DatabaseType.MySQL => "server=localhost;user=youdlovetogetthatright;password=1234hahaha",
                DatabaseType.SQLite => $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\library.db")}",
                DatabaseType.MongoDB => "mongodb://localhost:27017",
                DatabaseType.API => "https://api.thiscouldbeanexamplemaybe.com",
                _ => throw new ArgumentOutOfRangeException(nameof(dbType), dbType, null)
            };
        }
    }
}
