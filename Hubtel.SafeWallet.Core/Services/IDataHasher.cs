using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace Hubtel.SafeWallet.Core.Services
{
    public interface IDataHasher
    {
        string HashAccountNumber(string accountNumber);
        bool VerifyHashedAccountNumber(string accountNumber, string hashedAccountNumber);
    }
    public class DataHasher : IDataHasher
    {
        public string HashAccountNumber(string accountNumber)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(accountNumber));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public bool VerifyHashedAccountNumber(string accountNumber, string hashedAccountNumber)
        {
            string newlyHashed = HashAccountNumber(accountNumber);
            return string.Equals(newlyHashed, hashedAccountNumber, StringComparison.OrdinalIgnoreCase);
        }
    }
}
