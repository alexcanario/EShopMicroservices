using Microsoft.EntityFrameworkCore;

namespace EShop.Discount.Grpc.Database;

public static class Extensions
{
	public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
	{
		using var scope = app.ApplicationServices.CreateScope();
		var context = scope.ServiceProvider.GetRequiredService<DiscountContext>();
		context.Database.MigrateAsync();
		
		return app;
	}
}