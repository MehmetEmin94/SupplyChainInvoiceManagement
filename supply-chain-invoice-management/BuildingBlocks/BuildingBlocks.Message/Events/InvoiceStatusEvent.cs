
using BuildingBlocks.Message.Enums;

namespace BuildingBlocks.Message.Events
{
    public class InvoiceStatusEvent
    {
        public string InvoiceNumber { get; set; }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public decimal InvoiceCost { get; set; }
        public InvoiceStatus InvoiceStatus { get; set; }
    }
}
