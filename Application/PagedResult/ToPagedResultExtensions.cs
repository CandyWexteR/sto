namespace Application.PagedResult;

public static class ToPagedResultExtensions
{
    public static PagedResult<T> ToPagedResult<T>(this IEnumerable<T> values, PagedResultInputModel model)
    {
        var page = model.Page < 1 ? 1 : model.Page;
        var pageSize = model.PageSize < 1 ? 10 : model.PageSize;
        var skip = (page - 1) * pageSize;

        var totalItemsCount = values.Count();
        
        var items = values.Skip(skip).Take(pageSize).ToList();

        return new PagedResult<T>()
        {
            PageSize = pageSize,
            Page = page,
            Items = items,
            TotalItemsCount = totalItemsCount
        };
    }
}