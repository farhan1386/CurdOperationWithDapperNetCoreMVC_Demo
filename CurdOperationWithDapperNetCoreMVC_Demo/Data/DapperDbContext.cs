using Microsoft.Data.SqlClient;
using System.Data;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connection;

        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connection);
    }
}
