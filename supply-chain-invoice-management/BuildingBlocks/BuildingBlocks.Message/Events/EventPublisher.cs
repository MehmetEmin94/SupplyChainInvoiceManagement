using MassTransit;

namespace BuildingBlocks.Message.Events
{
    public class EventPublisher(IBus bus)
    {
        public async Task PublishInvoiceUploadedEvent(InvoiceUploadedEvent invoiceUploadedEvent)
        {
            await bus.Publish(invoiceUploadedEvent);
        }

        public async Task PublishInvoiceStatusEvent(InvoiceStatusEvent invoiceStatusEvent)
        {
            await bus.Publish(invoiceStatusEvent);
        }
    }
}
