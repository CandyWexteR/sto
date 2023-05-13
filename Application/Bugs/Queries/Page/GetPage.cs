using Application.Bugs.ViewModels;
using Application.CQRS;
using Application.PagedResult;

namespace Application.Bugs.Queries.Page;

public class GetPage : PagedResultInputModel, IQuery<PagedResult<BugShortViewModel>>
{
    
}