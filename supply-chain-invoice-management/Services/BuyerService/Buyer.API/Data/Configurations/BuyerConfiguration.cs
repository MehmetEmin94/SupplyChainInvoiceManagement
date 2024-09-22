using Buyer.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Buyer.API.Data.Configurations
{
    public class BuyerConfiguration : IEntityTypeConfiguration<BuyerModel>
    {
        public void Configure(EntityTypeBuilder<BuyerModel> builder)
        {
            builder.HasKey(i => i.TaxId);

            builder.HasMany(o => o.Invoices).WithOne().HasForeignKey(i => i.BuyerTaxId).HasPrincipalKey(b=>b.TaxId);
        }
    }
}
