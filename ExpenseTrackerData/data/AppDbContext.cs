using ExpenseTrackerData.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerData.data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // One-to-One relationship between User and Wallet
            modelBuilder.Entity<User>()
                .HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<Wallet>(w => w.UserID);

            // Prevent cascade delete between Wallet and CreditCard
            modelBuilder.Entity<CreditCard>()
                .HasOne(cc => cc.Wallet)
                .WithMany(w => w.CreditCards)
                .HasForeignKey(cc => cc.WalletID)
                .OnDelete(DeleteBehavior.Restrict);  // Disable cascading delete for Wallet

            // Prevent cascade delete between CreditCard and BillingAddress
            modelBuilder.Entity<CreditCard>()
                .HasOne(cc => cc.BillingAddress)
                .WithMany()
                .HasForeignKey(cc => cc.BillingAddressID)
                .OnDelete(DeleteBehavior.Restrict);  // Disable cascading delete for Address

            base.OnModelCreating(modelBuilder);
        }
    }
}
