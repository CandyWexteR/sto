using Application.CQRS;
using Application.PagedResult;

namespace Application.UserRoles.Queries.GetPage;

public class GetRolesPage : PagedResultInputModel, IQuery<PagedResult<UserRoleViewModel>>
{
    
}