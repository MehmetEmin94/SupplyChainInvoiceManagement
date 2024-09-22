using BuildingBlocks.CQRS;
using BuildingBlocks.Message.Enums;
using Supplier.API.Data.Invoice;

namespace Supplier.API.Supplier.Commands.EarlyPayment
{
    public record EarlyPaymentCommand(string InvoiceNumber)
        : ICommand<EarlyPaymentResult>;
    public record EarlyPaymentResult(bool IsSuccess);
    public class EarlyPaymentCommandHandler(IInvoiceRepository repository)
        : ICommandHandler<EarlyPaymentCommand, EarlyPaymentResult>
    {
        public async Task<EarlyPaymentResult> Handle(EarlyPaymentCommand command, CancellationToken cancellationToken)
        {
            await repository.UpdateInvoiceStatus(command.InvoiceNumber,InvoiceStatus.Used);

            return new EarlyPaymentResult(true);
        }
    }
}
