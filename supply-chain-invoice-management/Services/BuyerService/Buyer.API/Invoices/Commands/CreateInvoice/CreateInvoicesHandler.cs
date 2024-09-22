using BuildingBlocks.CQRS;
using Buyer.API.Data.Invoice;
using Buyer.API.Dtos;
using Buyer.API.Models;
using Mapster;

namespace Buyer.API.Invoices.Commands.CreateInvoice
{
    public record CreateInvoicesCommand(List<InvoiceDto> Invoices)
        : ICommand<CreateInvoicesResult>;

    public record CreateInvoicesResult(bool IsSuccess);
    public class CreateInvoicesCommandHandler(IInvoiceRepository repository)
        : ICommandHandler<CreateInvoicesCommand, CreateInvoicesResult>
    {
        public async Task<CreateInvoicesResult> Handle(CreateInvoicesCommand command, CancellationToken cancellationToken)
        {
            var invoices = command.Invoices.Adapt<List<InvoiceModel>>();

            await repository.CreateInvoices(invoices);

            return new CreateInvoicesResult(true);
        }
    }
}
