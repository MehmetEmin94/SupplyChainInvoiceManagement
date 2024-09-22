using Finance.API.Model;

namespace Finance.API.Data
{
    public interface IInvoiceClaimRepository
    {
        Task<List<InvoiceClaim>> GetAll();
        Task<bool> Approve(string InvoiceNumber);
    }
}
