using Buyer.API.Data;
using Buyer.API.Data.Extentions;
using Carter;
using Microsoft.EntityFrameworkCore;
using BuildingBlocks.Message.MassTransit;
using BuildingBlocks.Message.Events;
using Buyer.API.Data.Invoice;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddDbContext<BuyerDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddMessageBroker(builder.Configuration, assembly);

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<EventPublisher>();


var app = builder.Build();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
