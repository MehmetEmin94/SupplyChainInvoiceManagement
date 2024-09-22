using Supplier.API.Models;

namespace Supplier.API.Data.Supplier
{
    public interface ISupplierRepository
    {
        Task Create(SupplierModel supplier);
        Task Delete(string taxId);
        Task<SupplierModel> GetSupplier(string taxId);
    }
}
