using Microsoft.EntityFrameworkCore;
using Supplier.API.Models;
using System.Reflection;

namespace Supplier.API.Data
{
    public class SupplierDbContext : DbContext
    {
        public SupplierDbContext(DbContextOptions<SupplierDbContext> options) : base(options) { }

        public DbSet<SupplierModel> Suppliers => Set<SupplierModel>();
        public DbSet<InvoiceModel> Invoices => Set<InvoiceModel>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
