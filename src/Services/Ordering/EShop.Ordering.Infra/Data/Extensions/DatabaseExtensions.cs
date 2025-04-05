using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Ordering.Infra.Data.Extensions;

public static class DatabaseExtensions
{
    public static async Task InitialiseDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<OrderingDbContext>();
        await context.Database.MigrateAsync();

        await SeedDataAsync(context);
    }

    private static async Task SeedDataAsync(OrderingDbContext context)
    {
        // Seed data here
        await SeedDataToCustomer(context);
        //await SeedDataToProduct(context);
        //await SeedDataToOrder(context);
    }

    private static async Task SeedDataToCustomer(OrderingDbContext context)
    {
        if (!await context.Customer.AnyAsync())
        {
            await context.Customer.AddRangeAsync(InitialData.Customers);
            await context.SaveChangesAsync();
        }
    }
}