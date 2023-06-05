using Application.CQRS;

namespace Application.Users.Commands.UpdateUserToken;

public class UpdateUserToken : ICommand
{
    public Guid Id { get; set; }
}