using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Ordering.Infra.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
	public void Configure(EntityTypeBuilder<Customer> builder)
	{
		builder.Property(c => c.Id).HasConversion(
				customerId => customerId.Value,
				dbId => CustomerId.Of(dbId));

		builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
		builder.Property(c => c.Email).IsRequired().HasMaxLength(255);
		builder.HasIndex(c => c.Email).IsUnique();
	}
}