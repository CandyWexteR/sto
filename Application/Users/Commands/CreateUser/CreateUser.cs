using Application.CQRS;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Users.Commands.CreateUser;

public class CreateUser : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Email { get; set; }
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public string Number { get; set; }
}