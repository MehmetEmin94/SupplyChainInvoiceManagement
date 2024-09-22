
using BuildingBlocks.Message.Events;
using Carter;
using Finance.API.Data;
using Finance.API.Data.Extentions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddDbContext<FinanceDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddScoped<IInvoiceClaimRepository, InvoiceClaimRepository>();
builder.Services.AddScoped<EventPublisher>();

var app = builder.Build();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
