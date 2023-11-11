using Hubtel.SafeWallet.Core.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Domain.Repository
{
    public class DbRepository
    {
        private readonly IConfiguration _configuration;
        public DbRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<NpgsqlConnection> GetConnection()
        {
            var connectionString = _configuration.GetConnectionString("SafeWallet");

            var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
