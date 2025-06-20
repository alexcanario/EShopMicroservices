using EShop.Discount.Grpc.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Discount.Grpc.Seed;

public static class Seed
{
	public static void SeedCoupon(this EntityTypeBuilder<Coupon> modelBuilder)
	{
		modelBuilder.HasData(
			new Coupon { Id = 1, ProductName = "Iphone X", Description = "Iphone discount", Amount = 150 },
			new Coupon { Id = 2, ProductName = "Samsung 10", Description = "Samsung discount", Amount = 20 }
		);
	}
}	