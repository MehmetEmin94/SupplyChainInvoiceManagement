using BuildingBlocks.Message.Enums;

namespace Buyer.API.Models
{
    public class InvoiceModel
    {
        public Guid Id { get; set; }
        public string InvoiceNumber { get; set; }

        private DateTime _termDate;

        public DateTime TermDate
        {
            get => _termDate;
            set => _termDate = (value.Kind == DateTimeKind.Unspecified) ?
                DateTime.SpecifyKind(value, DateTimeKind.Utc) :
                value.ToUniversalTime();
        }
        public string BuyerTaxId { get; set; }
        public string SupplierTaxId { get; set; }
        public decimal InvoiceCost { get; set; }
        public InvoiceStatus Status { get; set; } = InvoiceStatus.New;
    }
}
