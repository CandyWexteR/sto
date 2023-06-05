using Application.CQRS;
using Core.Models.Users;

namespace Application.Users.Queries.GetSingle;

public class GetUserViaLoginPassword : IQuery<User>
{
    public string Username { get; set; }
    public string Password { get; set; }
}