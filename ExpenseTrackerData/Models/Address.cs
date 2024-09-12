using System.ComponentModel.DataAnnotations;

namespace ExpenseTrackerData.Models
{
    public class Address
    {
        [Key]
        public Guid AddressID { get; set; }
        public int StreetNumber { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
