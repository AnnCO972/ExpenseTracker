using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerData.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; } // navigation property
        public Guid AddressID { get; set; } //Foreign key

        public Wallet Wallet { get; set; } // one-to-one relationship with wallet
        
    }
}
    