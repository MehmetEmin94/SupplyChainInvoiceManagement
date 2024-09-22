using BuildingBlocks.Message.Events;
using Finance.API.Model;
using Microsoft.EntityFrameworkCore;
using BuildingBlocks.Message.Enums;

namespace Finance.API.Data
{
    public class InvoiceClaimRepository(FinanceDbContext dbContext, EventPublisher eventPublisher)
        : IInvoiceClaimRepository
    {
        public async Task<bool> Approve(string InvoiceNumber)
        {
            var invoice = await dbContext.InvoiceClaims.FirstOrDefaultAsync(s => s.InvoiceNumber == InvoiceNumber);

            invoice.IsApproved = true;

            await dbContext.SaveChangesAsync();

            var eventToPublish = new InvoiceStatusEvent { InvoiceNumber = InvoiceNumber, BuyerTaxId= invoice.BuyerTaxId,SupplierTaxId=invoice.SupplierTaxId, InvoiceCost=invoice.InvoiceCost, InvoiceStatus = InvoiceStatus.Paid };

            await eventPublisher.PublishInvoiceStatusEvent(eventToPublish);

            return true;
        }

        public async Task<List<InvoiceClaim>> GetAll()
        {
            return await dbContext.InvoiceClaims.ToListAsync();
        }
    }
}
