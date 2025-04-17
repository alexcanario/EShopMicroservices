using System.Reflection;

namespace EShop.Ordering.Infra.Data;

public class OrderingDbContext(DbContextOptions<OrderingDbContext> options) : DbContext(options)
{
	public DbSet<Customer> Customer => Set<Customer>();
	public DbSet<Product> Products => Set<Product>();
	public DbSet<Order> Orders => Set<Order>();
	public DbSet<OrderItem> OrderItems => Set<OrderItem>();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		//modelBuilder.ApplyConfiguration(new EntityConfiguration<Customer, CustomerId>());
		//modelBuilder.ApplyConfiguration(new EntityConfiguration<Product, ProductId>());
		//modelBuilder.ApplyConfiguration(new EntityConfiguration<Order, OrderId>());
		//modelBuilder.ApplyConfiguration(new EntityConfiguration<OrderItem, OrderItemId>());

		base.OnModelCreating(modelBuilder);

		//InitialData.Seed(modelBuilder);
	}
}