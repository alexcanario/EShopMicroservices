using EShop.Ordering.Domain.Abstractions;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Ordering.Infra.Data.Configurations;

public class EntityConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TKey>
{
	public virtual void Configure(EntityTypeBuilder<TEntity> builder)
	{
		builder.HasKey(e => e.Id);

		builder.Property(e => e.CreatedAt)
			.IsRequired(false)
			.HasDefaultValueSql("GETDATE()");

		builder.Property(e => e.CreatedBy)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(e => e.LastModified)
			.IsRequired(false);

		builder.Property(e => e.LastModifiedBy)
			.IsRequired(false)
			.HasMaxLength(50);
	}
}