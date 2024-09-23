using BuildingBlocks.Message.Events;
using BuildingBlocks.Message.MailService;
using BuildingBlocks.Message.MassTransit;
using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Supplier.API.Data;
using Supplier.API.Data.Extentions;
using Supplier.API.Data.Invoice;
using Supplier.API.Data.Supplier;
using Supplier.API.Services.TokenService;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddDbContext<SupplierDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});



builder.Services.AddAuthorization();
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])
        )
    };
});

builder.Services.AddMessageBroker(builder.Configuration, assembly);

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<EventPublisher>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapCarter();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}

app.Run();
