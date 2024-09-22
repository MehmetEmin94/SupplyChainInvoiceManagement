using BuildingBlocks.Message.Enums;
using Buyer.API.Models;

namespace Buyer.API.Data.Invoice
{
    public interface IInvoiceRepository
    {
        Task CreateInvoices(List<InvoiceModel> Invoices);
        Task<InvoiceModel> GetInvoice(string InvoiceNumber);
        Task UpdateInvoiceStatus(string invoiceNumber, InvoiceStatus invoiceStatus);
    }
}
