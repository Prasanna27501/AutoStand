using Npgsql;
using System.Data;
namespace AutoStandpro.Config
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AutoConnection");
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);

        internal void ReleaseServerConnection(IDbConnection connection)
        {
            throw new NotImplementedException();
        }
    }
}