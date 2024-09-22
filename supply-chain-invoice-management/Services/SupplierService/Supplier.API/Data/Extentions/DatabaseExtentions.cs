using Microsoft.EntityFrameworkCore;

namespace Supplier.API.Data.Extentions
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<SupplierDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}
