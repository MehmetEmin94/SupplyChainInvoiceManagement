using Buyer.API.Dtos;
using Carter;
using Mapster;
using MediatR;

namespace Buyer.API.Invoices.Commands.CreateInvoice
{
    public record CreateInvoicesRequest(List<InvoiceDto> Invoices);

    public record CreateInvoicesResponse(bool IsSuccess);
    public class CreateInvoicesEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/invoices", async (CreateInvoicesRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateInvoicesCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<CreateInvoicesResponse>();

                return Results.Ok(response);
            })
            .WithName("CreateInvoices")
            .Produces<CreateInvoicesResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Invoices")
            .WithDescription("Create Invoices");
        }
    }
}
