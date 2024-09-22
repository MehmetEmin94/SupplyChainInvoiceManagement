namespace Finance.API.Model
{
    public class InvoiceClaim
    {
        public string InvoiceNumber { get; set; }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public decimal InvoiceCost { get; set; }
        public bool IsApproved { get; set; }
    }
}
