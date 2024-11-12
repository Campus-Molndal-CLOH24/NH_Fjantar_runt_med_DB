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
            switch (dbType)
            {
                case DatabaseType.MySQL:
                    _connectionString = "server=localhost;user=youdlovetogetthatright;password=1234hahaha";
                    break;
                case DatabaseType.SQLite:
                    string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\library.db");
                    _connectionString = $"Data Source={databasePath}";
                    break;
                case DatabaseType.MongoDB:
                    _connectionString = "mongodb://localhost:27017";
                    break;
                case DatabaseType.API:
                    _connectionString = "https://api.thiscouldbeanexamplemaybe.com";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dbType), dbType, null);
            }
        }
    }
}
