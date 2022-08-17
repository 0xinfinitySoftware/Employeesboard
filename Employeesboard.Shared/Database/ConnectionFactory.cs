using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Employeesboard.Shared.Database
{
    public interface IConnectionFactory
    {
        public DbConnection CreateConnection();
    }
    public class MysqlConnectionFactory : IConnectionFactory
    {
        private readonly string _connectionString;

        public MysqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbConnection CreateConnection()
        {
            using var con = new MySqlConnection(_connectionString);
            con.Open();
            return con;
        }
    }
}
