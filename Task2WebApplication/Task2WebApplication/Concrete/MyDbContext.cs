using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2WebApplication.Models;

namespace Task2WebApplication.Concrete
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("EFDbContext")
        {
        }
        public DbSet<MyClass> Classes { get; set; }
        public DbSet<GroupOfAccount> GroupOfAccounts{ get; set; }
        public DbSet<Account> Accounts { get; set; }
    }

   
}