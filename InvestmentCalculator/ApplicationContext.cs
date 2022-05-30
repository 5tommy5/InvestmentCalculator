using InvestmentCalculator.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentCalculator
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Investment> Investments { get; set; }
    }
}
