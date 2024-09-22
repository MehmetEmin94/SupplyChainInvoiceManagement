using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Supplier.API.Models;

namespace Supplier.API.Data.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceModel>
    {
        public void Configure(EntityTypeBuilder<InvoiceModel> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasOne<SupplierModel>().WithMany().HasForeignKey( i => i.SupplierTaxId).IsRequired();
        }
    }
}
