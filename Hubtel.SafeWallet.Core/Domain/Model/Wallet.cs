using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Domain.Model
{
    public class Wallet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
