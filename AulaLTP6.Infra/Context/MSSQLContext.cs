using AulaLTP6.Infra.Configuration;
using AulaLTP6.Infra.Infra;
using System.Data;
using System.Data.SqlClient;

namespace AulaLTP6.Infra.Context
{
    public class MSSQLContext : IDB
    {
        private SqlConnection _connection;
        private IDbConfiguration _connectionString;

        public MSSQLContext(IDbConfiguration connectionString) => _connectionString = connectionString;
        

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public IDbConnection GetCon()
        {
            return _connection = new SqlConnection(_connectionString.stringConnection);
        }
    }
}
