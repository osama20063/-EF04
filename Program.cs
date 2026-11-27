using System.Globalization;
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





           
        #region Program
        //internal class Program
        //{
        //    #region Main Entry Point
        //    static void Main(string[] args)
        //    {
        //        using var context = new BankDbContext();
        //        context.Database.Migrate();

        //        bool running = true;

        //        while (running)
        //        {
        //            Console.Clear();
        //            Console.WriteLine("========================================");
        //            Console.WriteLine("         National Bank Management       ");
        //            Console.WriteLine("========================================");
        //            Console.WriteLine("1) Add a new Customer");
        //            Console.WriteLine("2) Open a new Account for a Customer");
        //            Console.WriteLine("3) Update Account Status (Active / Closed)");
        //            Console.WriteLine("4) Remove an Account from a Customer");
        //            Console.WriteLine("5) List all Customers (with accounts)");
        //            Console.WriteLine("0) Exit");
        //            Console.WriteLine("========================================");
        //            Console.Write("Enter choice: ");

        //            string? input = Console.ReadLine()?.Trim();

        //            switch (input)
        //            {
        //                case "1":
        //                    AddCustomer(context);
        //                    Pause();
        //                    break;
        //                case "2":
        //                    OpenAccount(context);
        //                    Pause();
        //                    break;
        //                case "3":
        //                    UpdateAccountStatus(context);
        //                    Pause();
        //                    break;
        //                case "4":
        //                    RemoveAccountFromCustomer(context);
        //                    Pause();
        //                    break;
        //                case "5":
        //                    ListCustomersWithAccounts(context);
        //                    Pause();
        //                    break;
        //                case "0":
        //                    running = false;
        //                    break;
        //                default:
        //                    Console.WriteLine("Invalid choice. Please enter a number from the menu.");
        //                    Pause();
        //                    break;
        //            }
        //        }
        //    }
        //    #endregion

        //    #region Menu Actions
        //    static void AddCustomer(BankDbContext context)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Add New Customer");

        //        string fullName = ReadNonEmptyString("Full Name: ");
        //        string nationalId = ReadNonEmptyString("National ID: ");

        //        if (context.Customers.Any(c => c.NationalId == nationalId))
        //        {
        //            Console.WriteLine("Error: A customer with this National ID already exists.");
        //            return;
        //        }

        //        DateOnly dob = ReadDateOnly("Date of Birth (yyyy-MM-dd): ");
        //        string email = ReadNonEmptyString("Email: ");
        //        string phone = ReadNonEmptyString("Phone: ");
        //        string address = ReadNonEmptyString("Address: ");

        //        CustomerType customerType = ReadEnumChoice<CustomerType>(
        //            "Customer Type:\n1) Individual\n2) Business\nChoice: ",
        //            new[] { 1, 2 }
        //        );

        //        var customer = new Customer
        //        {
        //            FullName = fullName,
        //            NationalId = nationalId,
        //            DateOfBirth = dob,
        //            Email = email,
        //            PhoneNumber = phone,
        //            Address = address,
        //            CustomerType = customerType
        //        };

        //        context.Customers.Add(customer);
        //        context.SaveChanges();

        //        Console.WriteLine($"Customer created successfully. CustomerId = {customer.Id}");
        //    }

        //    static void OpenAccount(BankDbContext context)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Open New Account");

        //        string accountNumber = ReadNonEmptyString("Account Number: ");

        //        if (context.Accounts.Any(a => a.AccountNumber == accountNumber))
        //        {
        //            Console.WriteLine($"Error: Account '{accountNumber}' already exists.");
        //            return;
        //        }

        //        AccountType accountType = ReadEnumChoice<AccountType>(
        //            "Account Type:\n1) Savings\n2) Current\n3) Business\nChoice: ",
        //            new[] { 1, 2, 3 }
        //        );

        //        string branchCode = ReadNonEmptyString("Branch Code: ");
        //        int customerId = ReadInt("Customer Id: ");

        //        OwnershipType ownershipType = ReadEnumChoice<OwnershipType>(
        //            "Ownership Role:\n1) Primary\n2) CoHolder\nChoice: ",
        //            new[] { 1, 2 }
        //        );

        //        Console.WriteLine($"Validating branch '{branchCode}' and customer #{customerId}...");

        //        var branch = context.Branches.FirstOrDefault(b => b.Code == branchCode);
        //        var customer = context.Customers.FirstOrDefault(c => c.Id == customerId);

        //        if (branch is null)
        //        {
        //            Console.WriteLine($"Error: Branch '{branchCode}' does not exist.");
        //            return;
        //        }

        //        if (customer is null)
        //        {
        //            Console.WriteLine($"Error: Customer #{customerId} does not exist.");
        //            return;
        //        }

        //        decimal initialBalance = ReadDecimal("Initial Balance: ");

        //        var account = new Account
        //        {
        //            AccountNumber = accountNumber,
        //            CurrentBalance = initialBalance,
        //            AccountType = accountType,
        //            OpeningDate = DateOnly.FromDateTime(DateTime.Today),
        //            BranchCode = branch.Code
        //        };

        //        var customerAccount = new CustomerAccount
        //        {
        //            CustomerId = customer.Id,
        //            AccountNumber = account.AccountNumber,
        //            OwnershipType = ownershipType,
        //            OwnershipStartDate = DateOnly.FromDateTime(DateTime.Today),
        //            AccountStatus = AccountStatus.Active
        //        };

        //        context.Accounts.Add(account);
        //        context.CustomerAccounts.Add(customerAccount);
        //        context.SaveChanges();

        //        Console.WriteLine($"Account '{accountNumber}' created and linked to customer {customerId} as {ownershipType} owner.");
        //    }

        //    static void UpdateAccountStatus(BankDbContext context)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Update Account Status");

        //        string accountNumber = ReadNonEmptyString("Account Number: ");
        //        int customerId = ReadInt("Customer Id: ");

        //        var customerAccount = context.CustomerAccounts
        //            .FirstOrDefault(ca => ca.AccountNumber == accountNumber && ca.CustomerId == customerId);

        //        if (customerAccount is null)
        //        {
        //            Console.WriteLine("Error: No ownership record found for this Account Number and Customer Id.");
        //            return;
        //        }

        //        AccountStatus newStatus = ReadEnumChoice<AccountStatus>(
        //            "New Status:\n1) Active\n2) Closed\nChoice: ",
        //            new[] { 1, 2 }
        //        );

        //        customerAccount.AccountStatus = newStatus;
        //        context.SaveChanges();

        //        Console.WriteLine($"Status updated to {newStatus}.");
        //    }

        //    static void RemoveAccountFromCustomer(BankDbContext context)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Remove Account From Customer");

        //        string accountNumber = ReadNonEmptyString("Account Number: ");
        //        int customerId = ReadInt("Customer Id: ");

        //        var customerAccount = context.CustomerAccounts
        //            .FirstOrDefault(ca => ca.AccountNumber == accountNumber && ca.CustomerId == customerId);

        //        if (customerAccount is null)
        //        {
        //            Console.WriteLine("Error: Ownership link not found.");
        //            return;
        //        }

        //        context.CustomerAccounts.Remove(customerAccount);
        //        context.SaveChanges();
        //        Console.WriteLine("Ownership link deleted.");

        //        bool hasRemainingOwners = context.CustomerAccounts.Any(ca => ca.AccountNumber == accountNumber);
        //        if (!hasRemainingOwners)
        //        {
        //            var account = context.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        //            if (account is not null)
        //            {
        //                context.Accounts.Remove(account);
        //                context.SaveChanges();
        //                Console.WriteLine("That was the last owner");
        //                Console.WriteLine($"account '{accountNumber}' was also removed.");
        //            }
        //        }
        //    }

        //    static void ListCustomersWithAccounts(BankDbContext context)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("All Customers");

        //        var customers = context.Customers
        //            .Include(c => c.CustomerAccounts)
        //                .ThenInclude(ca => ca.Account)
        //            .OrderBy(c => c.Id)
        //            .ToList();

        //        if (customers.Count == 0)
        //        {
        //            Console.WriteLine("No customers found.");
        //            return;
        //        }

        //        foreach (var customer in customers)
        //        {
        //            Console.WriteLine($"#{customer.Id} {customer.FullName} ({customer.CustomerType})");

        //            if (customer.CustomerAccounts.Count == 0)
        //            {
        //                Console.WriteLine("  (no accounts)");
        //            }
        //            else
        //            {
        //                foreach (var ca in customer.CustomerAccounts)
        //                {
        //                    Console.WriteLine($"  {ca.Account.AccountNumber} ({ca.Account.AccountType}) Balance: {ca.Account.CurrentBalance:N2} {ca.OwnershipType} {ca.AccountStatus}");
        //                }
        //            }
        //        }
        //    }
            #endregion

            #region Input Helpers
    //        static string ReadNonEmptyString(string prompt)
    //        {
    //            while (true)
    //            {
    //                Console.Write(prompt);
    //                string? value = Console.ReadLine()?.Trim();
    //                if (!string.IsNullOrWhiteSpace(value))
    //                    return value;

    //                Console.WriteLine("Input cannot be empty. Please try again.");
    //            }
    //        }

    //        static int ReadInt(string prompt)
    //        {
    //            while (true)
    //            {
    //                Console.Write(prompt);
    //                if (int.TryParse(Console.ReadLine()?.Trim(), out int result))
    //                    return result;

    //                Console.WriteLine("Invalid number. Please enter a valid integer.");
    //            }
    //        }

    //        static decimal ReadDecimal(string prompt)
    //        {
    //            while (true)
    //            {
    //                Console.Write(prompt);
    //                if (decimal.TryParse(Console.ReadLine()?.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result) && result >= 0)
    //                    return result;

    //                Console.WriteLine("Invalid amount. Please enter a valid non-negative number.");
    //            }
    //        }

    //        static DateOnly ReadDateOnly(string prompt)
    //        {
    //            while (true)
    //            {
    //                Console.Write(prompt);
    //                if (DateOnly.TryParseExact(Console.ReadLine()?.Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly date))
    //                    return date;

    //                Console.WriteLine("Invalid date format. Please use yyyy-MM-dd (e.g., 2000-01-25).");
    //            }
    //        }

    //        static TEnum ReadEnumChoice<TEnum>(string prompt, int[] validValues) where TEnum : struct, Enum
    //        {
    //            while (true)
    //            {
    //                Console.Write(prompt);
    //                if (int.TryParse(Console.ReadLine()?.Trim(), out int choice) && validValues.Contains(choice) && Enum.IsDefined(typeof(TEnum), choice))
    //                {
    //                    return (TEnum)Enum.ToObject(typeof(TEnum), choice);
    //                }

    //                Console.WriteLine("Invalid choice. Please select one of the listed options.");
    //            }
    //        }

    //        static void Pause()
    //        {
    //            Console.WriteLine("Press any key to return to the menu...");
    //            Console.ReadKey(true);
    //        }
    //        #endregion
    //    }
    //    #endregion
    //}

}
}
