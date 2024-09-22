using Carter;
using Mapster;
using MediatR;
using Supplier.API.Dtos;
using Supplier.API.Supplier.Commands.SupplierRegister;

namespace Supplier.API.Supplier.Commands.SupplierLogin
{
    public record SupplierLoginRequest(SupplierLoginDto SupplierLogin);
    public record SupplierLoginResponse(string token);
    public class SupplierLoginEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/supplier/login", async (SupplierLoginRequest request, ISender sender) =>
            {
                var command = request.Adapt<SupplierLoginCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<SupplierLoginResponse>();

                return Results.Ok(response);
            })
             .WithName("SupplierLogin")
             .Produces<SupplierLoginResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status400BadRequest)
             .WithSummary("Supplier Login")
             .WithDescription("Supplier Login");
        }
    }
}
