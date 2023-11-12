using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Domain.Model
{
    [Table("wallet")]
    public class Wallet
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("account_scheme")]
        public string AccountScheme { get; set; }
        [Column("account_number")]
        public string AccountNumber { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("owner")]
        public string Owner { get; set; }
        [Column("hashed_account_no")]
        public string HashedAccountNumber { get; set; }
        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; }
    }
}
