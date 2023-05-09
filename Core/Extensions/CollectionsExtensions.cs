using Core.Models;

namespace Core.Extensions;

public static class CollectionsExtensions
{
    public static bool ContainsAll(this IEnumerable<IdableEntity> t, IEnumerable<Guid> ids)
    {
        return ids.All(v => t.Any(b => b.Id == v));
    }
}