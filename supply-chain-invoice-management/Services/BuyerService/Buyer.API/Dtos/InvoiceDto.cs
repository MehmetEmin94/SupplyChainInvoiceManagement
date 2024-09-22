using Buyer.API.Models;

namespace Buyer.API.Dtos
{
    public record InvoiceDto(string InvoiceNumber, DateTime TermDate,
        string BuyerTaxId, string SupplierTaxId, decimal InvoiceCost);
}
