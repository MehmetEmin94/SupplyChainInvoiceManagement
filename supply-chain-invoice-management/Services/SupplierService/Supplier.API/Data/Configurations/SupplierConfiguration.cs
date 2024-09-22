using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supplier.API.Models;

namespace Supplier.API.Data.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<SupplierModel>
    {
        public void Configure(EntityTypeBuilder<SupplierModel> builder)
        {
            builder.HasKey(i => i.TaxId);

            builder.HasMany( s => s.Invoices).WithOne().HasForeignKey( i => i.SupplierTaxId).HasPrincipalKey(b => b.TaxId);
        }
    }
}
