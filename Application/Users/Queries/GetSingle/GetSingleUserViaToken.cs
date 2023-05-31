using Application.CQRS;

namespace Application.Users.Queries.GetSingle;

public class GetSingleUserViaToken : IQuery<UserViewModel>
{
    public string Token { get; set; }
}