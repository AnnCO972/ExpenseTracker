using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerData.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionID { get; set; }

        public Guid WalletID { get; set; } //foreign key for wallet 
        public Wallet Wallet { get; set; } //navigation property

        public Guid CreditCardID { get; set; } //foreign key for creditcard
        public CreditCard CreditCard { get; set; } //navigation property
        [Column(TypeName ="decimal(18,2)")] //precision for the amount field
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Vendor { get; set; }
        public string Category { get; set; }
        public string ReceiptURL { get; set; }

       
        
    }
}
