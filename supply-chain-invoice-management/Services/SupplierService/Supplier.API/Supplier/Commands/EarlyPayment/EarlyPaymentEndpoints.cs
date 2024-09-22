using Carter;
using Mapster;
using MediatR;

namespace Supplier.API.Supplier.Commands.EarlyPayment
{
    public record EarlyPaymentRequest(string InvoiceNumber);
    public record EarlyPaymentResponse(bool IsSuccess);
    public class EarlyPaymentEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/supplier/invoice/early-payment", async (EarlyPaymentRequest request, ISender sender) => 
            {
                var command = request.Adapt<EarlyPaymentCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<EarlyPaymentResponse>();

                return Results.Ok(response);
            })
            .WithName("EarlyPayment")
            .Produces<EarlyPaymentResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Early Payment")
            .WithDescription("Early Payment");
        }
    }
}
