using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.UserRoles.Queries.GetSingle;

public class GetSingleRoleHandler : IQueryHandler<GetSingleRole, RoleViewModel>
{
    private readonly IUserRolesRepository _userRoles;

    public GetSingleRoleHandler(IUserRolesRepository userRoles)
    {
        _userRoles = userRoles;
    }

    public async Task<RoleViewModel> Handle(GetSingleRole request, CancellationToken cancellationToken)
    {
        var userRole = await _userRoles.GetByIdAsync(request.RoleId);

        userRole.ThrowIfNull();
        
        return new RoleViewModel()
        {
            Id = userRole.Id,
            Name = userRole.Name,
            Description = userRole.Description,
            Users = userRole.Users,
            Inventory = userRole.Inventory,
            ComponentsOrderings = userRole.ComponentsOrderings,
            ServiceOrders = userRole.ServiceOrders,
            Docs = userRole.Docs,
            Bugs = userRole.Bugs,
            Vehicles = userRole.Vehicles
        };
    }
}