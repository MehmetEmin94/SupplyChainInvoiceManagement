using Microsoft.EntityFrameworkCore;
using Supplier.API.Models;

namespace Supplier.API.Data.Supplier
{
    public class SupplierRepository(SupplierDbContext dbContext) : ISupplierRepository
    {
        public async Task Create(SupplierModel supplier)
        {
            dbContext.Suppliers.Add(supplier);
            await dbContext.SaveChangesAsync();
        }

        public async Task Delete(string taxId)
        {
            var supplier = await dbContext.Suppliers.FirstOrDefaultAsync(s => s.TaxId == taxId);
            dbContext.Suppliers.Remove(supplier);
            await dbContext.SaveChangesAsync();
        }

        public async Task<SupplierModel> GetSupplier(string taxId)
        {
            return await dbContext.Suppliers.FirstOrDefaultAsync(s => s.TaxId == taxId);
        }
    }
}
