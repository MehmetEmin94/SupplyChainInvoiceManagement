

namespace BuildingBlocks.Message.Events
{
    public class InvoiceUploadedEvent
    {
        public List<InvoiceEventModel> InvoiceEventModels { get; set; }
    }

    public class InvoiceEventModel
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime TermDate { get; set; }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public decimal InvoiceCost { get; set; }
    }
}
