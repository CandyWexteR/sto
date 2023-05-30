using Application.CQRS;
using Core.Models.UserRoles;
using Core.Repositories;

namespace Application.UserRoles.Commands.Create;

public class CreateUserRoleHandler : ICommandHandler<CreateUserRole>
{
    private readonly IUserRolesRepository _userRoles;

    public CreateUserRoleHandler(IUserRolesRepository userRoles)
    {
        _userRoles = userRoles;
    }

    public Task Handle(CreateUserRole request, CancellationToken cancellationToken)
    {
        var userRole = UserRole.Create(request.Id, request.Name, request.Description, request.Users, request.Inventory,
            request.ComponentsOrderings, request.ServiceOrders, request.Docs, request.Bugs, request.Vehicles);

        return _userRoles.AddAsync(userRole);
    }
}