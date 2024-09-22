namespace Supplier.API.Models
{
    public class SupplierModel
    {
        public string TaxId { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string? Email { get; set; }
        public ICollection<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();
    }
}
