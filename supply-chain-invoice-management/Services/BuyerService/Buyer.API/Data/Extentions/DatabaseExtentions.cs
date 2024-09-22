using Microsoft.EntityFrameworkCore;

namespace Buyer.API.Data.Extentions
{
    public static class DatabaseExtentions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<BuyerDbContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await SeedAsync(context);
        }

        private static async Task SeedAsync(BuyerDbContext context)
        {
            await SeedBuyerAsync(context);
        }

        private static async Task SeedBuyerAsync(BuyerDbContext context)
        {
            if (!await context.Buyers.AnyAsync())
            {
                await context.Buyers.AddRangeAsync(InitialData.Buyers);
                await context.SaveChangesAsync();
            }
        }
    }
}
