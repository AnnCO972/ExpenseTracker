using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerData.Models
{
    public class CreditCard
    {
        [Key]
        public Guid CreditCardID { get; set; }

        public Guid WalletID { get; set; }  // Foreign key for Wallet
        public Wallet Wallet { get; set; }  // Navigation property

        public string CardholderName { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string CardType { get; set; }

        public Guid BillingAddressID { get; set; }  // Foreign key for Address
        public Address BillingAddress { get; set; }  // Navigation property
    }
}