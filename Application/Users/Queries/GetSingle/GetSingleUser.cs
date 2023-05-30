using Application.CQRS;

namespace Application.Users.Queries.GetSingle;

public class GetSingleUser : IQuery<UserViewModel>
{
    public Guid UserId { get; set; }
}