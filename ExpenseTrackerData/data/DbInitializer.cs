using ExpenseTrackerData.Models;

namespace ExpenseTrackerData.data
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            //Ensure database is created 
            context.Database.EnsureCreated();

            //Check to see if table user already seeded
            if (context.Users.Any())
            {
                return;
            }
            //Seed Address data
            var address1 = new Address
            {
                AddressID = Guid.NewGuid(),
                StreetNumber = 123,
                StreetAddress = "Main Street",
                City = "Metropolis",
                ZipCode = "10001",
                State = "NY",
                Country = "USA"
            };
            var address2 = new Address
            {
                AddressID = Guid.NewGuid(),
                StreetNumber = 456,
                StreetAddress = "Elm Street",
                City = "Gotham",
                ZipCode = "10002",
                State = "NY",
                Country = "USA"
            };
            context.Addresses.AddRange(address1, address2);

            // Seed User data
            var user1 = new User
            {
                UserId = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Doe",
                Birthdate = new DateTime(1980, 1, 1),
                EmailAddress = "john.doe@example.com",
                PhoneNumber = "1234567890",
                AddressID = address1.AddressID
            };

            var user2 = new User
            {
                UserId = Guid.NewGuid(),
                Firstname = "Jane",
                Lastname = "Smith",
                Birthdate = new DateTime(1985, 5, 15),
                EmailAddress = "jane.smith@example.com",
                PhoneNumber = "0987654321",
                AddressID = address2.AddressID
            };

            context.Users.AddRange(user1, user2);

            //Seed wallet data
            var wallet1 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                UserID = user1.UserId
            };

            var wallet2 = new Wallet
            {
                WalletID = Guid.NewGuid(),
                UserID = user2.UserId
            };

            context.Wallets.AddRange(wallet1, wallet2);

            // Seed Credit Card data
            var creditCard1 = new CreditCard
            {
                CreditCardID = Guid.NewGuid(),
                WalletID = wallet1.WalletID,
                CardholderName = "John Doe",
                ExpiryDate = new DateTime(2025, 12, 31),
                CardType = "Visa",
                BillingAddressID = address1.AddressID
            };

            var creditCard2 = new CreditCard
            {
                CreditCardID = Guid.NewGuid(),
                WalletID = wallet2.WalletID,
                CardholderName = "Jane Smith",
                ExpiryDate = new DateTime(2024, 11, 30),
                CardType = "MasterCard",
                BillingAddressID = address2.AddressID
            };

            context.CreditCards.AddRange(creditCard1, creditCard2);

            // Seed Transaction data
            var transaction1 = new Transaction
            {
                TransactionID = Guid.NewGuid(),
                WalletID = wallet1.WalletID,
                CreditCardID = creditCard1.CreditCardID,
                Amount = 100.50m,
                TransactionDate = DateTime.Now,
                Vendor = "Amazon",
                Category = "Shopping"
            };

            var transaction2 = new Transaction
            {
                TransactionID = Guid.NewGuid(),
                WalletID = wallet2.WalletID,
                CreditCardID = creditCard2.CreditCardID,
                Amount = 200.00m,
                TransactionDate = DateTime.Now,
                Vendor = "Ebay",
                Category = "Electronics"
            };

            context.Transactions.AddRange(transaction1, transaction2);

            // Save the seeded data
            context.SaveChanges();
        }
    }
}
