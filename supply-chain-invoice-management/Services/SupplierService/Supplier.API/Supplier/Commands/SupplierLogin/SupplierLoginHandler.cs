
using BuildingBlocks.CQRS;
using Supplier.API.Data.Supplier;
using Supplier.API.Dtos;
using Supplier.API.Services.TokenService;

namespace Supplier.API.Supplier.Commands.SupplierLogin
{
    public record SupplierLoginCommand(SupplierLoginDto SupplierLogin)
        : ICommand<SupplierLoginResult>;
    public record SupplierLoginResult(string token);
    public class SupplierLoginCommandHandler(ISupplierRepository repository, ITokenService tokenHelper)
        : ICommandHandler<SupplierLoginCommand, SupplierLoginResult>
    {
        public async Task<SupplierLoginResult> Handle(SupplierLoginCommand command, CancellationToken cancellationToken)
        {
            var supplier = await repository.GetSupplier(command.SupplierLogin.TaxId);

            var isVerified=!BCrypt.Net.BCrypt.Verify(command.SupplierLogin.Password, supplier.PasswordHash);

            if (supplier == null || isVerified)
                throw new Exception("Invalid TaxId or password.");

            var token = tokenHelper.CreateToken(supplier);

            return new SupplierLoginResult(token);
        }
    }
}
