using Buyer.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Buyer.API.Data
{
    public class BuyerDbContext : DbContext
    {
        public BuyerDbContext(DbContextOptions<BuyerDbContext> options) : base(options) { }

        public DbSet<InvoiceModel> Invoices => Set<InvoiceModel>();
        public DbSet<BuyerModel> Buyers => Set<BuyerModel>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
