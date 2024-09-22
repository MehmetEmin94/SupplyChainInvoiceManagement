using BuildingBlocks.CQRS;
using Supplier.API.Data.Supplier;
using Supplier.API.Dtos;
using Supplier.API.Services.TokenService;
using Supplier.API.Models;

namespace Supplier.API.Supplier.Commands.SupplierRegister
{
    public record SupplierRegisterCommand(SupplierRegisterDto SupplierRegister) 
        : ICommand<SupplierRegisterResult>;
    public record SupplierRegisterResult(string token);
    public class SupplierRegisterCommandHandler(ISupplierRepository repository, ITokenService tokenHelper)
        : ICommandHandler<SupplierRegisterCommand, SupplierRegisterResult>
    {
        public async Task<SupplierRegisterResult> Handle(SupplierRegisterCommand command, CancellationToken cancellationToken)
        {
            var supplier = await repository.GetSupplier(command.SupplierRegister.TaxId);

            if (supplier == null)
                throw new Exception("Supplier already exist!");
            
            supplier = new SupplierModel
            {
                TaxId = command.SupplierRegister.TaxId,
                Name = command.SupplierRegister.Name,
                Email = command.SupplierRegister.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.SupplierRegister.Password)
            };

            await repository.Create(supplier);

            var token = tokenHelper.CreateToken(supplier);

            return new SupplierRegisterResult (token);
        }
    }
}
