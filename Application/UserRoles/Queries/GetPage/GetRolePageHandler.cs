using Application.CQRS;
using Application.PagedResult;
using Core.Repositories;

namespace Application.UserRoles.Queries.GetPage;

public class GetRolePageHandler : IQueryHandler<GetRolesPage,PagedResult<UserRoleViewModel>>
{
    private readonly IUserRolesRepository _roles;

    public GetRolePageHandler(IUserRolesRepository roles)
    {
        _roles = roles;
    }

    public async Task<PagedResult<UserRoleViewModel>> Handle(GetRolesPage request, CancellationToken cancellationToken)
    {
        var all = await _roles.GetAllAsync();
        var allView = all.Select(v => new UserRoleViewModel()
        {
            Id = v.Id,
            Name = v.Name
        });

        return allView.ToPagedResult(request);
    }
}