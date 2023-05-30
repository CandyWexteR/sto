using Application.CQRS;
using Application.UserRoles.Commands.Create;
using Core.Extensions;
using Core.Repositories;

namespace Application.UserRoles.Commands.UpdateRoleInfo;

public class UpdateRoleInfoHandler : ICommandHandler<CreateUserRole>
{
    private readonly IUserRolesRepository _userRoles;

    public UpdateRoleInfoHandler(IUserRolesRepository userRoles)
    {
        _userRoles = userRoles;
    }

    public async Task Handle(CreateUserRole request, CancellationToken cancellationToken)
    {
        var role = await _userRoles.GetByIdAsync(request.Id);
        role.ThrowIfNull();
        role.UpdateInfo(request.Name, request.Description, request.Users, request.Inventory,
            request.ComponentsOrderings, request.ServiceOrders, request.Docs, request.Bugs, request.Vehicles);
        await _userRoles.UpdateAsync(role);
    }
}