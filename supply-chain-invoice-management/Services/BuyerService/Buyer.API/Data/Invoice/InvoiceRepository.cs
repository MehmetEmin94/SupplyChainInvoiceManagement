using BuildingBlocks.Message.Enums;
using BuildingBlocks.Message.Events;
using Buyer.API.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Buyer.API.Data.Invoice
{
    public class InvoiceRepository(BuyerDbContext _dbContext, EventPublisher eventPublisher)
        : IInvoiceRepository
    {
        public async Task CreateInvoices(List<InvoiceModel> Invoices)
        {
            _dbContext.Invoices.AddRange(Invoices);
            await _dbContext.SaveChangesAsync();

            var eventToPublish = new InvoiceUploadedEvent { InvoiceEventModels = Invoices.Adapt<List<InvoiceEventModel>>() };

            await eventPublisher.PublishInvoiceUploadedEvent(eventToPublish);
        }

        public async Task<InvoiceModel> GetInvoice(string InvoiceNumber)
        {
            return await _dbContext.Invoices.FirstOrDefaultAsync(s => s.InvoiceNumber == InvoiceNumber);
        }

        public async Task UpdateInvoiceStatus(string invoiceNumber, InvoiceStatus invoiceStatus)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(s => s.InvoiceNumber == invoiceNumber);

            invoice.Status = invoiceStatus;

            await _dbContext.SaveChangesAsync();
        }
    }
}
