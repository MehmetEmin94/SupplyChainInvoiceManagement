using BuildingBlocks.Message.Enums;
using BuildingBlocks.Message.Events;
using BuildingBlocks.Message.MailService;
using MassTransit;
using Supplier.API.Data.Invoice;
using Supplier.API.Data.Supplier;

namespace Supplier.API.Supplier.EventHandlers.Integration
{
    public class InvoiceStatusConsumer(ISupplierRepository supplierRepository, IInvoiceRepository invoiceRepository, IEmailService emailService)
        : IConsumer<InvoiceStatusEvent>
    {
        public async Task Consume(ConsumeContext<InvoiceStatusEvent> context)
        {
            var message = context.Message;

            await invoiceRepository.UpdateInvoiceStatus(message.InvoiceNumber, message.InvoiceStatus);


            var supplier = await supplierRepository.GetSupplier(message.SupplierTaxId);
            if (supplier != null)
            {
                await emailService.SendEmailAsync(supplier.Email, $"New Invoice {message.InvoiceStatus}",
                $"An invoice with amount {message.InvoiceCost} has been {message.InvoiceStatus}.");
            }
            
        }
    }
}
