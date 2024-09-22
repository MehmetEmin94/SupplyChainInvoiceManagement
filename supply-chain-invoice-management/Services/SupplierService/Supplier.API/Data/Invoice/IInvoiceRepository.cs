using BuildingBlocks.Message.Enums;
using Supplier.API.Models;

namespace Supplier.API.Data.Invoice
{
    public interface IInvoiceRepository
    {
        Task CreateInvoice(InvoiceModel Invoice);
        Task UpdateInvoiceStatus(string InvoiceNumber, InvoiceStatus status);
        Task<InvoiceModel> GetInvoice(string InvoiceNumber);
    }
}
