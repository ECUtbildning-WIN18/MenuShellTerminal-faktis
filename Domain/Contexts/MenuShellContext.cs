using Microsoft.EntityFrameworkCore;

namespace Domain.Contexts
{
    public class MenuShellContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<SystemAdministrator> Admin { get; set; }
        public DbSet<Expense> Expense { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(local);Database=MenuShell;Trusted_Connection=True;");
            
        }

    }
}