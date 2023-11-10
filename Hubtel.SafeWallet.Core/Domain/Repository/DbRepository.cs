using Hubtel.SafeWallet.Core.Domain.Model;
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
        private ConnectionStringOption _connectionString;
        public DbRepository(IOptions<ConnectionStringOption> connectionString)
        {
            _connectionString = connectionString.Value ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public async Task<NpgsqlConnection> GetConnection()
        {
            var connection = new NpgsqlConnection(_connectionString.SafeWallet);
            await connection.OpenAsync();
            return connection;
        }
    }
}
