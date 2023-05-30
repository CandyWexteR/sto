using Application.CQRS;

namespace Application.UserRoles.Commands.RemoveRole;

public class RemoveRole : ICommand
{
    public Guid Id { get; set; }
}