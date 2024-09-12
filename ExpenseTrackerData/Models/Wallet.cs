using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerData.Models
{
    public class Wallet
    {
        [Key]
        public Guid WalletID { get; set; }
        public Guid UserID { get; set; } //Foreign key user
        public User User { get; set; } //navigation property 
        public List<CreditCard> CreditCards { get; set; } //one to many relationship with creditcards
    }
}
