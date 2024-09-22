using BuildingBlocks.CQRS;
using Supplier.API.Data.Supplier;
using Supplier.API.Models;

namespace Supplier.API.Supplier.Queries.GetInvoicesBySupplier
{
    public record GetInvoicesBySupplierQuery(string taxId)
        : ICommand<GetInvoicesBySupplierResult>;
    public record GetInvoicesBySupplierResult(List<InvoiceModel> Invoices);
    public class GetInvoicesBySupplierQueryHandler(ISupplierRepository repository)
        : ICommandHandler<GetInvoicesBySupplierQuery, GetInvoicesBySupplierResult>
    {
        public async Task<GetInvoicesBySupplierResult> Handle(GetInvoicesBySupplierQuery query, CancellationToken cancellationToken)
        {
            var supplier = await repository.GetSupplier(query.taxId);

            return new GetInvoicesBySupplierResult(supplier.Invoices.ToList());
        }
    }
}
