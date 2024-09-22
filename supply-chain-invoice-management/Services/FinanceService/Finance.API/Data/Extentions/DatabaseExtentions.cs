using Microsoft.EntityFrameworkCore;

namespace Finance.API.Data.Extentions
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<FinanceDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}
