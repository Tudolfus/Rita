using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Database.Migrations
{
    public static class DatabaseMigration
    {
        public static void EnsureDatabase(string connectionString, string name)
        {
            var parameters = new DynamicParameters();
            parameters.Add("name", name);

            using var connection = new SqlConnection(connectionString);

            var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
                 parameters);

            if (!records.Any())
            {
                connection.Execute($"CREATE DATABASE {name}");
            }
        }
    }
}