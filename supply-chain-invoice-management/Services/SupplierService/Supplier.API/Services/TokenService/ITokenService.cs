using Supplier.API.Models;

namespace Supplier.API.Services.TokenService
{
    public interface ITokenService
    {
        string CreateToken(SupplierModel supplier);
    }
}
