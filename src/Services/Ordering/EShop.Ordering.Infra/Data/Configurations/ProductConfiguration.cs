using EShop.Ordering.Domain.Models;
using EShop.Ordering.Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Ordering.Infra.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.HasKey(p => p.Id);

		builder.Property(p => p.Id).HasConversion(productId => productId.Value, dbId => ProductId.Of(dbId));
		builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
		builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
	}
}