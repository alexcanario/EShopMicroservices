using EShop.Ordering.Domain.Enums;
using EShop.Ordering.Domain.Models;
using EShop.Ordering.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Ordering.Infra.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.HasKey(o => o.Id);

		builder.Property(o => o.Id).HasConversion(id => id.Value, dbId => OrderId.Of(dbId));

		builder.HasOne<Customer>().WithMany().HasForeignKey(o => o.CustomerId).IsRequired();
		builder.HasMany<OrderItem>().WithOne().HasForeignKey(oi => oi.OrderId).IsRequired();

		builder.ComplexProperty(o => o.OrderName, nameBuilder => 
			nameBuilder.Property(n => n.Value).HasColumnName(nameof(Order.OrderName)).HasMaxLength(100).IsRequired());

		builder.ComplexProperty(o => o.ShippingAddress, addressBuilder =>
		{
			addressBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
			addressBuilder.Property(a => a.Country).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.State).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.ZipCode).HasMaxLength(8).IsRequired();
		});

		builder.ComplexProperty(a => a.BillingAddress, addressBuilder => 
		{
			addressBuilder.Property(a => a.FirstName).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.LastName).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.EmailAddress).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.AddressLine).HasMaxLength(180).IsRequired();
			addressBuilder.Property(a => a.Country).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.State).HasMaxLength(50).IsRequired();
			addressBuilder.Property(a => a.ZipCode).HasMaxLength(8).IsRequired();
		});

		builder.ComplexProperty(p => p.Payment, paymentBuilder =>
		{
			paymentBuilder.Property(p => p.CardName).HasMaxLength(50).IsRequired();
			paymentBuilder.Property(p => p.CardNumber).HasMaxLength(25).IsRequired();
			paymentBuilder.Property(p => p.Expiration).HasMaxLength(5).IsRequired();
			paymentBuilder.Property(p => p.CVV).HasMaxLength(3).IsRequired();
			paymentBuilder.Property(p => p.PaymentMethod);
		});

		builder.Property(o => o.Status).HasDefaultValue(OrderStatus.Draft)
			.HasConversion(s => s.ToString(), dbStatus => Enum.Parse<OrderStatus>(dbStatus));

		builder.Property(o => o.TotalPrice);
	}
}