using Finance.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.API.Data.Configurations
{
    public class InvoiceClaimConfiguration : IEntityTypeConfiguration<InvoiceClaim>
    {
        public void Configure(EntityTypeBuilder<InvoiceClaim> builder)
        {
            builder.HasKey(i => i.InvoiceNumber);
        }
    }
}
