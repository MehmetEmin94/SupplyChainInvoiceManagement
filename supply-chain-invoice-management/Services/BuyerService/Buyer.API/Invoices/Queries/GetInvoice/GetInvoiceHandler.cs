using BuildingBlocks.CQRS;
using Buyer.API.Data.Invoice;
using Buyer.API.Models;

namespace Buyer.API.Invoices.Queries.GetInvoice
{
    public record GetInvoiceQuery(string invoiceNumber)
        : IQuery<GetInvoiceResult>;
    public record GetInvoiceResult
        (InvoiceModel InvoiceModel);
    public class GetInvoiceQueryHandler(IInvoiceRepository repository)
        : IQueryHandler<GetInvoiceQuery, GetInvoiceResult>
    {
        public async Task<GetInvoiceResult> Handle(GetInvoiceQuery query, CancellationToken cancellationToken)
        {
            var invoice = await repository.GetInvoice(query.invoiceNumber);

            return new GetInvoiceResult(invoice);
        }
    }
}
