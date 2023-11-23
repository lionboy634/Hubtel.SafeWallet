using Dapper;
using Hubtel.SafeWallet.Core.Data;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Services;
using Microsoft.EntityFrameworkCore;
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
        Task RemoveWallet(int walletId, string owner);
        Task<bool> CheckExistingUserWallet(string accountNumber, string phonenumber);
        Task<int> GetUserWalletCount(string phoneNumber);
        Task<bool> CheckDuplicateAccount(string owner, string account_number);
        Task<IEnumerable<Wallet>> GetUserWallets(string owner);
        Task<Wallet?> VerifyUserWallet(int walletId, string owner);
    }
    public class WalletRepository : DbRepository, IWalletRepository
    {
        private readonly AppDbContext _dbContext;
        public WalletRepository(IConfiguration configuration, AppDbContext dbContext) : base(configuration)
        {
            _dbContext = dbContext;
        }

        public async Task AddWallet(Wallet wallet)
        {
            await _dbContext.AddAsync(wallet);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckDuplicateAccount(string owner, string accountNumber)
        {
            var hashedAccountNumberToCheck = DataHash.HashValue(accountNumber);

            var accounts = await _dbContext.Wallet
                .Where(c => c.Owner == owner && c.HashedAccountNumber == hashedAccountNumberToCheck)
                .ToListAsync();

            return accounts.Any();
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

        public async Task RemoveWallet(int walletId, string owner)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    DELETE FROM public.wallet
                    WHERE id = @WalletId AND owner = @Owner
                ";
                await connection.ExecuteScalarAsync(query, new
                {
                    WalletId = walletId,
                    Owner = owner
                });

            }
        }

        public async Task<bool> CheckExistingUserWallet(string accountNumber, string phonenumber)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    SELECT EXISTS(
                        SELECT * FROM public.wallet
                        WHERE account_number = @AccountNumber
                        AND owner = @PhoneNumber
                    )
                ";
                return await connection.ExecuteScalarAsync<bool>(query, new
                {
                    AccountNumber = accountNumber,
                    PhoneNumber = phonenumber
                });

            }
        }

        public async Task<int> GetUserWalletCount(string phoneNumber)
        {
            using (var connection = await GetConnection())
            {
                var query = @"
                    SELECT count(1) FROM public.wallet
                    WHERE owner = @PhoneNumber
                ";
                return await connection.ExecuteScalarAsync<int>(query, new
                {
                    PhoneNumber = phoneNumber
                });

            }
        }

        public async Task<IEnumerable<Wallet>> GetUserWallets(string owner)
        {
            return await _dbContext.Wallet.Where(c => c.Owner == owner).ToListAsync();
        }

        public async Task<Wallet?> VerifyUserWallet(int walletId, string owner)
        {
            return await _dbContext.Wallet.Where(c => c.Id == walletId && c.Owner == owner).FirstOrDefaultAsync();
        }
    }
}

