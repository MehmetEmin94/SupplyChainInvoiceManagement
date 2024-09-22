using BuildingBlocks.Message.Enums;

namespace Supplier.API.Models
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TermDate { get; set; }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public decimal InvoiceCost { get; set; }
        public InvoiceStatus Status { get; set; }
    }
}
