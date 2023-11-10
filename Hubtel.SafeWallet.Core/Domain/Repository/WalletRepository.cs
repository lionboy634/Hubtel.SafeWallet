using Dapper;
using Hubtel.SafeWallet.Core.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Domain.Repository
{
    public interface IWalletRepository
    {
        Task AddWallet(Wallet wallet);
        Task<Wallet> GetWalletByWalletId(int walletId);
        Task<IEnumerable<Wallet>> ListWallets();
        Task RemoveWallet(int walletId);
    }
    internal class WalletRepository : DbRepository, IWalletRepository
    {
        public WalletRepository(IOptions<ConnectionStringOption> connectionString) : base(connectionString)
        {

        }

        public async Task AddWallet(Wallet wallet)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                     INSERT INTO public.wallet(name, account_name, account_number)
                        VALUES(@Name, @AccountName, @AccountNumber)
                    ";
                await connection.ExecuteScalarAsync(query, new
                {
                    Name = wallet.Name,
                    AccountName = wallet.Name,
                    AccountNumber = wallet.AccountNumber.Substring(0, 6)
                });

            }
        }

        public async Task<Wallet> GetWalletByWalletId(int walletId)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    SELECT * FROM public.wallet
                    WHERE id = @Id
                ";
                return await connection.QueryFirstOrDefaultAsync<Wallet>(query, new
                {
                    Id = walletId
                });
            }
        }

        public async Task<IEnumerable<Wallet>> ListWallets()
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    SELECT * 
                        FROM public.wallet
                ";
                return await connection.QueryAsync<Wallet>(query);
            }
        }

        public async Task RemoveWallet(int walletId)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    DELETE FROM public.wallet
                    WHERE id = @WalletId
                ";
                await connection.ExecuteScalarAsync(query, new
                {
                    WalletId = walletId
                });

            }
        }

        public async Task<bool> CheckExistingUserWallet(string accountNumber)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    SELECT EXISTS(
                        SELECT * FROM public.wallet
                        WHERE account_number = @AccountNumber
                    )
                ";
                return await connection.ExecuteScalarAsync<bool>(query, new
                {
                    AccountNumber = accountNumber
                });

            }
        }

        public async Task<IEnumerable<Wallet>> GetUserWalletCount(string phoneNumber)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    SELECT 1 FROM public.wallet
                    WHERE owner = @PhoneNumber
                ";
                return await connection.QueryAsync<Wallet>(query);
            }
        }
    }
}

