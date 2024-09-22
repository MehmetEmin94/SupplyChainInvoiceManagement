using Carter;
using Mapster;
using MediatR;
using Supplier.API.Dtos;

namespace Supplier.API.Supplier.Commands.SupplierRegister
{
    public record SupplierRegisterRequest(SupplierRegisterDto SupplierRegister);
    public record SupplierRegisterResponse(string token);
    public class SupplierRegisterEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/supplier/register",async (SupplierRegisterRequest request,ISender sender) => 
            {
                var command = request.Adapt<SupplierRegisterCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<SupplierRegisterResponse>();

                return Results.Ok(response);
            })
            .WithName("SupplierRegister")
            .Produces<SupplierRegisterResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Supplier Register")
            .WithDescription("Supplier Register");
        }
    }
}
