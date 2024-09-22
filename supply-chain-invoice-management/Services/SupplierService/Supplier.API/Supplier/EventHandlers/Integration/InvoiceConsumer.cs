using BuildingBlocks.Message.Events;
using MassTransit;
using BuildingBlocks.Message.Enums;
using Supplier.API.Data.Invoice;
using Supplier.API.Data.Supplier;
using Supplier.API.Models;
using BuildingBlocks.Message.MailService;

namespace Supplier.API.Supplier.EventHandlers.Integration
{
    public class InvoiceConsumer(ISupplierRepository supplierRepository,IInvoiceRepository invoiceRepository, IEmailService emailService) 
        : IConsumer<InvoiceUploadedEvent>
    {
        public async Task Consume(ConsumeContext<InvoiceUploadedEvent> context)
        {
            var message = context.Message;

            foreach (var item in message.InvoiceEventModels)
            {
                var invoice = new InvoiceModel
                {
                    Id = item.Id,
                    InvoiceNumber = item.InvoiceNumber,
                    TermDate = item.TermDate,
                    BuyerTaxId = item.BuyerTaxId,
                    SupplierTaxId = item.SupplierTaxId,
                    InvoiceCost = item.InvoiceCost,
                    Status = InvoiceStatus.New
                };

                await invoiceRepository.CreateInvoice(invoice);

                var supplier = await supplierRepository.GetSupplier(item.SupplierTaxId);
                if (supplier != null)
                {
                    await emailService.SendEmailAsync(supplier.Email, "New Invoice Uploaded",
                        $"An invoice with amount {item.InvoiceCost} has been uploaded by Buyer {item.BuyerTaxId}.");
                }
            }
        }
    }
}
