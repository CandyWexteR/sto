using Application.CQRS;
using Application.UserRoles.Commands.Create;
using Core.Repositories;

namespace Application.UserRoles.Commands.RemoveRole;

public class RemoveRoleHandler : ICommandHandler<CreateUserRole>
{
    private readonly IUserRolesRepository _userRoles;

    public RemoveRoleHandler(IUserRolesRepository userRoles)
    {
        _userRoles = userRoles;
    }

    public Task Handle(CreateUserRole request, CancellationToken cancellationToken) => 
        _userRoles.RemoveAsync(request.Id);
}