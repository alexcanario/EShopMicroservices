using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Ordering.Infra.Data.Extensions;

public static class SeedExtensions
{
	public static async Task InitialiseDatabaseAsync(this WebApplication app)
	{
		using var scope = app.Services.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<OrderingDbContext>();									//961 001 620
		
		var pendingMigrations = await context.Database.GetPendingMigrationsAsync();
		if (pendingMigrations.Any())
			await context.Database.MigrateAsync();

		await SeedDataAsync(context);
	}

	private static async Task SeedDataAsync(OrderingDbContext context)
	{
		// Seed data here
		await SeedCustomerAsync(context);
		await SeedProductAsync(context);
		await SeedOrderWithItemsAsync(context);
	}

	private static async Task SeedCustomerAsync(OrderingDbContext context)
	{
		if (!await context.Customers.AnyAsync())
		{
			await context.Customers.AddRangeAsync(InitialData.Customers);
			await context.SaveChangesAsync();
		}
	}

	private static async Task SeedProductAsync(OrderingDbContext context)
	{
		if (!await context.Products.AnyAsync())
		{
			await context.Products.AddRangeAsync(InitialData.Products);
			await context.SaveChangesAsync();
		}
	}

	private static async Task SeedOrderWithItemsAsync(OrderingDbContext context)
	{
		if (!await context.Orders.AnyAsync())
		{
			await context.Orders.AddRangeAsync(InitialData.OrdersWithItems);
			await context.SaveChangesAsync();
		}
	}
}