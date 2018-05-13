namespace Bank
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BankDataModel : DbContext
    {
        public BankDataModel()
            : base("name=BankDataModel")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
