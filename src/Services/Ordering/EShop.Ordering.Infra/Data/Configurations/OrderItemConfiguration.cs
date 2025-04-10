using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Ordering.Infra.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.Property(oi => oi.Id).HasConversion(orderItemId => orderItemId.Value, dbId => OrderItemId.Of(dbId));
		builder.HasOne<Product>().WithMany().HasForeignKey(oi => oi.ProductId);
		builder.HasOne<Order>(oi => oi.Order).WithMany(o => o.OrderItems).HasForeignKey(oi => oi.OrderId);
		builder.Property(oi => oi.Quantity).IsRequired();
		builder.Property(oi => oi.UnitPrice).HasPrecision(18,2).IsRequired();
	}
}