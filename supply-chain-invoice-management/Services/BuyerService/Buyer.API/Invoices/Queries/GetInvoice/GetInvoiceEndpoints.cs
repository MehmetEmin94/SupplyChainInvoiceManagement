using Carter;
using Mapster;
using MediatR;
using Buyer.API.Models;

namespace Buyer.API.Invoices.Queries.GetInvoice
{
    public record GetInvoiceResponse(InvoiceModel InvoiceModel);
    public class GetInvoiceEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/invoice/{invoiceNumber}", async (string invoiceNumber, ISender sender) =>
            {
                var result = await sender.Send(new GetInvoiceQuery(invoiceNumber));

                var response = result.Adapt<GetInvoiceResponse>();

                return Results.Ok(response);
            })
            .WithName("GetInvoice")
            .Produces<GetInvoiceResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Invoice")
            .WithDescription("Get Invoice");
        }
    }
}
