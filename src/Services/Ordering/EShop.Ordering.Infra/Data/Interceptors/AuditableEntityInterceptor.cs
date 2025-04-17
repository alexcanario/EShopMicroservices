using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EShop.Ordering.Infra.Data.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		SetAuditableEntityProperties(eventData.Context!);
		return base.SavingChanges(eventData, result);
	}

	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
		CancellationToken cancellationToken = new CancellationToken())
	{
		SetAuditableEntityProperties(eventData.Context!);
		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	private static void SetAuditableEntityProperties(DbContext context)
	{
		const string defaultUser = "alexcanario";
		var entries = context.ChangeTracker.Entries<IEntity>();
		foreach (var entry in entries)
		{
			switch (entry.State)
			{
				case EntityState.Added:
					entry.Entity.CreatedAt = DateTime.UtcNow;
					entry.Entity.CreatedBy = defaultUser; 
					break;
				case EntityState.Modified:
					entry.Entity.LastModified = DateTime.UtcNow;
					entry.Entity.LastModifiedBy = defaultUser;
					break;
			}
		}
	}
}