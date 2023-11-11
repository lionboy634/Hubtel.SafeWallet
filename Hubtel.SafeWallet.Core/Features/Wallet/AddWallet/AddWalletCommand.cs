using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.AddWallet
{
    public class AddWalletCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }

        public AddWalletCommand(string name, string accountName, string accountNumber, string type, string owner)
        {
            Name = name;
            AccountName = accountName;
            AccountNumber = accountNumber;
            Type = type;
            Owner = owner;
        }
    }
}
