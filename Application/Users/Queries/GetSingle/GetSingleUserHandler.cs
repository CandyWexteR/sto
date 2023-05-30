using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.Users.Queries.GetSingle;

public class GetSingleUserHandler : IQueryHandler<GetSingleUser, UserViewModel>
{
    private readonly IUserRepository _users;

    public GetSingleUserHandler(IUserRepository users)
    {
        _users = users;
    }

    public async Task<UserViewModel> Handle(GetSingleUser request, CancellationToken cancellationToken)
    {
        var user = await _users.GetByIdAsync(request.UserId);

        user.ThrowIfNull();
        
        return new UserViewModel()
        {
            Id = user.Id,
            Username = user.Username,
            FirstName = user.FirstName,
            LastName = user.LastName,
            MiddleName = user.MiddleName,
            UserRoleId = user.UserRoleId,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
            AccessToken = user.AccessToken,
            AccessTokenExpirationDate = user.AccessTokenExpirationDate,
            RefreshToken = user.RefreshToken,
        };
    }
}