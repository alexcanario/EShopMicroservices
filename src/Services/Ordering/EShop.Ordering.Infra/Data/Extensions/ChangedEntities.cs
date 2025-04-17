using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EShop.Ordering.Infra.Data.Extensions;

public static class ChangedEntities
{
	public static bool HasChangedOwnedEntities(this EntityEntry entry)
	{
		 return entry.References.Any(r =>
			r.TargetEntry != null &&
			r.TargetEntry.Metadata.IsOwned() &&
			r.TargetEntry.State is EntityState.Added or EntityState.Modified);
	}
}