using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Models.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.Property(a => a.Balance).HasColumnType("decimal(18, 2)");
        }
    }
}


namespace BankApp.Models.Configuration
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.Property(l => l.Amount).HasColumnType("decimal(18, 2)");
            builder.Property(l => l.InterestRate).HasColumnType("decimal(18, 2)");
            builder.Property(l => l.MonthlyPayment).HasColumnType("decimal(18, 2)");
        }
    }
}


namespace BankApp.Models.Configuration
{
    public class MobileTopUpConfiguration : IEntityTypeConfiguration<MobileTopUp>
    {
        public void Configure(EntityTypeBuilder<MobileTopUp> builder)
        {
            builder.Property(m => m.Amount).HasColumnType("decimal(18, 2)");
        }
    }
}



namespace BankApp.Models.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.Property(t => t.Amount).HasColumnType("decimal(18, 2)");
        }
    }
}
