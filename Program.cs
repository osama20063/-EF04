using System.Reflection.Emit;
using System.Security.Principal;
using System.Transactions;

namespace Assignment_EF4
{
    internal class Program
    {
        static void Main(string[] args)
        {




            #region Enums
            //public enum AccountType
            //        {
            //            Savings = 1,
            //            Current = 2,
            //            Business = 3
            //        }

            //        public enum CustomerType
            //        {
            //            Individual = 1,
            //            Business = 2
            //        }

            //        public enum OwnershipType
            //        {
            //            Primary = 1,
            //            CoHolder = 2
            //        }

            //        public enum AccountStatus
            //        {
            //            Active = 1,
            //            Closed = 2
            //        }

            //        public enum TransactionType
            //        {
            //            Deposit = 1,
            //            Withdrawal = 2,
            //            Transfer = 3
            //        }
            #endregion


            #region Entities
            //public class Branch
            //        {
            //            public string Code { get; set; } = null!;
            //            public string Name { get; set; } = null!;
            //            public string Address { get; set; } = null!;
            //            public string PhoneNumber { get; set; } = null!;

            //            public Manager? Manager { get; set; }
            //            public ICollection<Account> Accounts { get; set; } = new HashSet<Account>();
            //        }

            //        public class Manager
            //        {
            //            public int Id { get; set; }
            //            public string FullName { get; set; } = null!;
            //            public string Email { get; set; } = null!;
            //            public string PhoneNumber { get; set; } = null!;
            //            public DateOnly HireDate { get; set; }

            //            public string BranchCode { get; set; } = null!;
            //            public Branch Branch { get; set; } = null!;
            //        }

            //        public class Account
            //        {
            //            public string AccountNumber { get; set; } = null!;
            //            public decimal CurrentBalance { get; set; }
            //            public AccountType AccountType { get; set; }
            //            public DateOnly OpeningDate { get; set; }

            //            public string BranchCode { get; set; } = null!;
            //            public Branch Branch { get; set; } = null!;

            //            public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();
            //            public ICollection<Transaction> Transactions { get; set; } = new HashSet<Transaction>();
            //        }

            //        public class Customer
            //        {
            //            public int Id { get; set; }
            //            public string FullName { get; set; } = null!;
            //            public string NationalId { get; set; } = null!;
            //            public DateOnly DateOfBirth { get; set; }
            //            public string Email { get; set; } = null!;
            //            public string PhoneNumber { get; set; } = null!;
            //            public string Address { get; set; } = null!;
            //            public CustomerType CustomerType { get; set; }

            //            public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new HashSet<CustomerAccount>();
            //        }

            //        public class CustomerAccount
            //        {
            //            public int CustomerId { get; set; }
            //            public Customer Customer { get; set; } = null!;

            //            public string AccountNumber { get; set; } = null!;
            //            public Account Account { get; set; } = null!;

            //            public OwnershipType OwnershipType { get; set; }
            //            public DateOnly OwnershipStartDate { get; set; }
            //            public AccountStatus AccountStatus { get; set; }
            //        }

            //        public class Transaction
            //        {
            //            public string TransactionNumber { get; set; } = null!;
            //            public DateTime TransactionDate { get; set; }
            //            public decimal Amount { get; set; }
            //            public TransactionType TransactionType { get; set; }
            //            public string? Note { get; set; }

            //            public string AccountNumber { get; set; } = null!;
            //            public Account Account { get; set; } = null!;
            //        }
            #endregion




            #region DbContext
            //public class BankDbContext : DbContext
            //        {
            //            public DbSet<Branch> Branches { get; set; }
            //            public DbSet<Manager> Managers { get; set; }
            //            public DbSet<Account> Accounts { get; set; }
            //            public DbSet<Customer> Customers { get; set; }
            //            public DbSet<CustomerAccount> CustomerAccounts { get; set; }
            //            public DbSet<Transaction> Transactions { get; set; }

            //            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //            {
            //                optionsBuilder.UseSqlServer("Server=.;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;");
            //            }

            //            protected override void OnModelCreating(ModelBuilder modelBuilder)
            //            {
            //                modelBuilder.Entity<Branch>(entity =>
            //                {
            //                    entity.HasKey(b => b.Code);
            //                    entity.Property(b => b.Code).HasMaxLength(20);
            //                    entity.Property(b => b.Name).HasMaxLength(100).IsRequired();
            //                    entity.Property(b => b.Address).HasMaxLength(250).IsRequired();
            //                    entity.Property(b => b.PhoneNumber).HasMaxLength(20).IsRequired();

            //                    entity.HasOne(b => b.Manager)
            //                          .WithOne(m => m.Branch)
            //                          .HasForeignKey<Manager>(m => m.BranchCode)
            //                          .IsRequired()
            //                          .OnDelete(DeleteBehavior.Restrict);
            //                });

            //                modelBuilder.Entity<Manager>(entity =>
            //                {
            //                    entity.HasKey(m => m.Id);
            //                    entity.Property(m => m.FullName).HasMaxLength(100).IsRequired();
            //                    entity.Property(m => m.Email).HasMaxLength(100).IsRequired();
            //                    entity.Property(m => m.PhoneNumber).HasMaxLength(20).IsRequired();
            //                    entity.HasIndex(m => m.BranchCode).IsUnique();
            //                });

            //                modelBuilder.Entity<Account>(entity =>
            //                {
            //                    entity.HasKey(a => a.AccountNumber);
            //                    entity.Property(a => a.AccountNumber).HasMaxLength(30);
            //                    entity.Property(a => a.CurrentBalance).HasColumnType("decimal(18,2)");
            //                    entity.Property(a => a.AccountType).HasConversion<string>().HasMaxLength(20);

            //                    entity.HasOne(a => a.Branch)
            //                          .WithMany(b => b.Accounts)
            //                          .HasForeignKey(a => a.BranchCode)
            //                          .IsRequired()
            //                          .OnDelete(DeleteBehavior.Restrict);
            //                });

            //                modelBuilder.Entity<Customer>(entity =>
            //                {
            //                    entity.HasKey(c => c.Id);
            //                    entity.Property(c => c.FullName).HasMaxLength(100).IsRequired();
            //                    entity.Property(c => c.NationalId).HasMaxLength(20).IsRequired();
            //                    entity.HasIndex(c => c.NationalId).IsUnique();
            //                    entity.Property(c => c.Email).HasMaxLength(100).IsRequired();
            //                    entity.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
            //                    entity.Property(c => c.Address).HasMaxLength(250).IsRequired();
            //                    entity.Property(c => c.CustomerType).HasConversion<string>().HasMaxLength(20);
            //                });

            //                modelBuilder.Entity<CustomerAccount>(entity =>
            //                {
            //                    entity.HasKey(ca => new { ca.CustomerId, ca.AccountNumber });
            //                    entity.Property(ca => ca.OwnershipType).HasConversion<string>().HasMaxLength(20);
            //                    entity.Property(ca => ca.AccountStatus).HasConversion<string>().HasMaxLength(20);

            //                    entity.HasOne(ca => ca.Customer)
            //                          .WithMany(c => c.CustomerAccounts)
            //                          .HasForeignKey(ca => ca.CustomerId)
            //                          .OnDelete(DeleteBehavior.Cascade);

            //                    entity.HasOne(ca => ca.Account)
            //                          .WithMany(a => a.CustomerAccounts)
            //                          .HasForeignKey(ca => ca.AccountNumber)
            //                          .OnDelete(DeleteBehavior.Cascade);
            //                });

            //                modelBuilder.Entity<Transaction>(entity =>
            //                {
            //                    entity.HasKey(t => t.TransactionNumber);
            //                    entity.Property(t => t.TransactionNumber).HasMaxLength(50);
            //                    entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
            //                    entity.Property(t => t.TransactionType).HasConversion<string>().HasMaxLength(20);
            //                    entity.Property(t => t.Note).HasMaxLength(500);

            //                    entity.HasOne(t => t.Account)
            //                          .WithMany(a => a.Transactions)
            //                          .HasForeignKey(t => t.AccountNumber)
            //                          .IsRequired()
            //                          .OnDelete(DeleteBehavior.Cascade);
            //                });
            //            }
            //        }
            #endregion






         
        #region DbContext
        //public class BankDbContext : DbContext
        //{
        //    public DbSet<Branch> Branches { get; set; }
        //    public DbSet<Manager> Managers { get; set; }
        //    public DbSet<Account> Accounts { get; set; }
        //    public DbSet<Customer> Customers { get; set; }
        //    public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        //    public DbSet<Transaction> Transactions { get; set; }

        //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    {
        //        optionsBuilder.UseSqlServer("Server=.;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;");
        //    }

        //    protected override void OnModelCreating(ModelBuilder modelBuilder)
        //    {
        //        modelBuilder.Entity<Branch>(entity =>
        //        {
        //            entity.HasKey(b => b.Code);
        //            entity.Property(b => b.Code).HasMaxLength(20);
        //            entity.Property(b => b.Name).HasMaxLength(100).IsRequired();
        //            entity.Property(b => b.Address).HasMaxLength(250).IsRequired();
        //            entity.Property(b => b.PhoneNumber).HasMaxLength(20).IsRequired();

        //            entity.HasOne(b => b.Manager)
        //                  .WithOne(m => m.Branch)
        //                  .HasForeignKey<Manager>(m => m.BranchCode)
        //                  .IsRequired()
        //                  .OnDelete(DeleteBehavior.Restrict);
        //        });

        //        modelBuilder.Entity<Manager>(entity =>
        //        {
        //            entity.HasKey(m => m.Id);
        //            entity.Property(m => m.FullName).HasMaxLength(100).IsRequired();
        //            entity.Property(m => m.Email).HasMaxLength(100).IsRequired();
        //            entity.Property(m => m.PhoneNumber).HasMaxLength(20).IsRequired();
        //            entity.HasIndex(m => m.BranchCode).IsUnique();
        //        });

        //        modelBuilder.Entity<Account>(entity =>
        //        {
        //            entity.HasKey(a => a.AccountNumber);
        //            entity.Property(a => a.AccountNumber).HasMaxLength(30);
        //            entity.Property(a => a.CurrentBalance).HasColumnType("decimal(18,2)");
        //            entity.Property(a => a.AccountType).HasConversion<string>().HasMaxLength(20);

        //            entity.HasOne(a => a.Branch)
        //                  .WithMany(b => b.Accounts)
        //                  .HasForeignKey(a => a.BranchCode)
        //                  .IsRequired()
        //                  .OnDelete(DeleteBehavior.Restrict);
        //        });

        //        modelBuilder.Entity<Customer>(entity =>
        //        {
        //            entity.HasKey(c => c.Id);
        //            entity.Property(c => c.FullName).HasMaxLength(100).IsRequired();
        //            entity.Property(c => c.NationalId).HasMaxLength(20).IsRequired();
        //            entity.HasIndex(c => c.NationalId).IsUnique();
        //            entity.Property(c => c.Email).HasMaxLength(100).IsRequired();
        //            entity.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
        //            entity.Property(c => c.Address).HasMaxLength(250).IsRequired();
        //            entity.Property(c => c.CustomerType).HasConversion<string>().HasMaxLength(20);
        //        });

        //        modelBuilder.Entity<CustomerAccount>(entity =>
        //        {
        //            entity.HasKey(ca => new { ca.CustomerId, ca.AccountNumber });
        //            entity.Property(ca => ca.OwnershipType).HasConversion<string>().HasMaxLength(20);
        //            entity.Property(ca => ca.AccountStatus).HasConversion<string>().HasMaxLength(20);

        //            entity.HasOne(ca => ca.Customer)
        //                  .WithMany(c => c.CustomerAccounts)
        //                  .HasForeignKey(ca => ca.CustomerId)
        //                  .OnDelete(DeleteBehavior.Cascade);

        //            entity.HasOne(ca => ca.Account)
        //                  .WithMany(a => a.CustomerAccounts)
        //                  .HasForeignKey(ca => ca.AccountNumber)
        //                  .OnDelete(DeleteBehavior.Cascade);
        //        });

        //        modelBuilder.Entity<Transaction>(entity =>
        //        {
        //            entity.HasKey(t => t.TransactionNumber);
        //            entity.Property(t => t.TransactionNumber).HasMaxLength(50);
        //            entity.Property(t => t.Amount).HasColumnType("decimal(18,2)");
        //            entity.Property(t => t.TransactionType).HasConversion<string>().HasMaxLength(20);
        //            entity.Property(t => t.Note).HasMaxLength(500);

        //            entity.HasOne(t => t.Account)
        //                  .WithMany(a => a.Transactions)
        //                  .HasForeignKey(t => t.AccountNumber)
        //                  .IsRequired()
        //                  .OnDelete(DeleteBehavior.Cascade);
        //        });

        //        #region Seeding
        //        modelBuilder.Entity<Branch>().HasData(
        //            new Branch
        //            {
        //                Code = "CAI-01",
        //                Name = "Cairo Main Branch",
        //                Address = "Tahrir Square, Cairo, Egypt",
        //                PhoneNumber = "0227940001"
        //            },
        //            new Branch
        //            {
        //                Code = "ALX-01",
        //                Name = "Alexandria Branch",
        //                Address = "Corniche Road, Alexandria, Egypt",
        //                PhoneNumber = "035820002"
        //            }
        //        );

        //        modelBuilder.Entity<Manager>().HasData(
        //            new Manager
        //            {
        //                Id = 1,
        //                FullName = "Tarek Mansour",
        //                Email = "tarek.mansour@nationalbank.eg",
        //                PhoneNumber = "01001112233",
        //                HireDate = new DateOnly(2020, 3, 15),
        //                BranchCode = "CAI-01"
        //            },
        //            new Manager
        //            {
        //                Id = 2,
        //                FullName = "Heba Hassan",
        //                Email = "heba.hassan@nationalbank.eg",
        //                PhoneNumber = "01004445566",
        //                HireDate = new DateOnly(2021, 7, 1),
        //                BranchCode = "ALX-01"
        //            }
        //        
        #endregion
    }


}
    }
}
