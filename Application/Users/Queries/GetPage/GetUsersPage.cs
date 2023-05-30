using Application.CQRS;
using Application.PagedResult;

namespace Application.Users.Queries.GetPage;

public class GetUsersPage : PagedResultInputModel, IQuery<PagedResult<UserViewModel>>
{
    
}