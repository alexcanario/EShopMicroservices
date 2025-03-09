namespace EShop.Ordering.Domain.Abstractions;

public abstract class Entity<T> : IEntity<T>
{
	public required T Id { get; set; }
	public DateTime? CreatedAt { get; set; }
	public string CreatedBy { get; set; } = string.Empty;
	public DateTime? LastModified { get; set; }
	public string? LastModifiedBy { get; set; } = string.Empty;
}