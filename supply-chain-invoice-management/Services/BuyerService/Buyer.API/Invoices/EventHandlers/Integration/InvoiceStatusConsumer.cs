using BuildingBlocks.Message.Enums;
using BuildingBlocks.Message.Events;
using BuildingBlocks.Message.MailService;
using Buyer.API.Data;
using Buyer.API.Data.Invoice;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Buyer.API.Invoices.EventHandlers.Integration
{
    public class InvoiceStatusConsumer(BuyerDbContext dbContext,IInvoiceRepository invoiceRepository, IEmailService emailService)
        : IConsumer<InvoiceStatusEvent>
    {
        public async Task Consume(ConsumeContext<InvoiceStatusEvent> context)
        {
            var message = context.Message;

            await invoiceRepository.UpdateInvoiceStatus(message.InvoiceNumber, message.InvoiceStatus);


            var buyer =await dbContext.Buyers.FirstOrDefaultAsync(b => b.TaxId == message.BuyerTaxId);
            if (buyer != null)
            {
                await emailService.SendEmailAsync(buyer.Email, $"New Invoice {message.InvoiceStatus}",
                $"An invoice with amount {message.InvoiceCost} has been {message.InvoiceStatus}.");
            }
        }
    }
}
