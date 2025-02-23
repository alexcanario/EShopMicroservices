using EShop.Discount.Grpc.Models;
using EShop.Discount.Grpc.Seed;

using Microsoft.EntityFrameworkCore;

namespace EShop.Discount.Grpc.Database;

public class DiscountContext(DbContextOptions options) : DbContext(options) 
{
	public DbSet<Coupoun> Coupouns { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Coupoun>().SeedCoupoun();
	}
}