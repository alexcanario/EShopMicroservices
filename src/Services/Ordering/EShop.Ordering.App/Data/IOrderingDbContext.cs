using EShop.Ordering.Domain.Models;

using Microsoft.EntityFrameworkCore;

namespace EShop.Ordering.App.Data;

public interface IOrderingDbContext
{
	DbSet<Customer> Customers { get; }
	DbSet<Order> Orders { get; }
	DbSet<Product> Products { get; }
	DbSet<OrderItem> OrderItems { get; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}