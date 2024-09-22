using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Supplier.API.Dtos;
using Supplier.API.Models;

namespace Supplier.API.Supplier.Queries.GetInvoicesBySupplier
{
    public record GetInvoicesBySupplierResponse(List<InvoiceModel> Invoices);
    public class GetInvoicesBySupplierEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/supplier/invoices",async (string taxId,ISender sender) => 
            {
                var result = await sender.Send(new GetInvoicesBySupplierQuery(taxId));

                var response = result.Adapt<GetInvoicesBySupplierResponse>();

                return Results.Ok(response);
            })
            .WithName("GetInvoicesBySupplier")
            .Produces<GetInvoicesBySupplierResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Invoices By Supplier")
            .WithDescription("Get Invoices By Supplier");
        }
    }
}
