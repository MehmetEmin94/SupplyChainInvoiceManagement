using BuildingBlocks.Message.Enums;
using BuildingBlocks.Message.Events;
using Microsoft.EntityFrameworkCore;
using Supplier.API.Models;

namespace Supplier.API.Data.Invoice
{
    public class InvoiceRepository(SupplierDbContext _dbContext, EventPublisher eventPublisher)
        : IInvoiceRepository
    {
        public async Task CreateInvoice(InvoiceModel Invoice)
        {
            _dbContext.Invoices.Add(Invoice);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<InvoiceModel> GetInvoice(string InvoiceNumber)
        {
            return await _dbContext.Invoices.FirstOrDefaultAsync(s => s.InvoiceNumber == InvoiceNumber);
        }

        public async Task UpdateInvoiceStatus(string InvoiceNumber, InvoiceStatus status)
        {
            var invoice = await _dbContext.Invoices.FirstOrDefaultAsync(s => s.InvoiceNumber == InvoiceNumber);

            invoice.Status = status;

            await _dbContext.SaveChangesAsync();

            var eventToPublish = new InvoiceStatusEvent 
            { 
                InvoiceNumber = invoice.InvoiceNumber, 
                BuyerTaxId = invoice.BuyerTaxId, 
                SupplierTaxId = invoice.SupplierTaxId, 
                InvoiceCost = invoice.InvoiceCost, 
                InvoiceStatus = status
            };

            await eventPublisher.PublishInvoiceStatusEvent(eventToPublish);
        }
    }
}
