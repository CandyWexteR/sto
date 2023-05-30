using Application.Bugs.Queries.ViewModels;
using Application.CQRS;
using Application.PagedResult;
using Core.Repositories;

namespace Application.Bugs.Queries.Page;

public class GetPageHandler : IQueryHandler<GetPage, PagedResult<BugShortViewModel>>
{
    private readonly IBugsRepository _repos;

    public GetPageHandler(IBugsRepository repos)
    {
        _repos = repos;
    }

    public async Task<PagedResult<BugShortViewModel>> Handle(GetPage request, CancellationToken cancellationToken)
    {
        var items = await _repos.GetAllAsync();

        return items.Select(v => new BugShortViewModel() { Id = v.Id, Title = v.Title }).ToPagedResult(request);
    }
}