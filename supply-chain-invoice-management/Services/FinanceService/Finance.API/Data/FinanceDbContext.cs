using Finance.API.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Finance.API.Data
{
    public class FinanceDbContext: DbContext
    {
        public FinanceDbContext(DbContextOptions<FinanceDbContext> options) : base(options) { }

        public DbSet<InvoiceClaim> InvoiceClaims => Set<InvoiceClaim>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
