using EShop.Discount.Grpc.Models;

using Microsoft.EntityFrameworkCore;

namespace EShop.Discount.Grpc.Database;

public class DiscountContext(DbContextOptions options) : DbContext(options) {

	public DbSet<Coupoun> Coupouns { get; set; }
}