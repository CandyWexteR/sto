namespace Application.PagedResult;

public class PagedResult<T>
{
    public int PageSize { get; set; }
    public int Page { get; set; }
    public int TotalItemsCount { get; set; }
    public List<T> Items { get; set; }
}