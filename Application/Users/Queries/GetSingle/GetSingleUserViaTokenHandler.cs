using Application.CQRS;
using Core.Encryption;
using Core.Extensions;
using Core.Repositories;

namespace Application.Users.Queries.GetSingle;

public class GetSingleUserViaTokenHandler : IQueryHandler<GetSingleUserViaToken, UserViewModel>
{
    private readonly IUserRepository _users;
    private readonly IDecrypter _decrypter;

    public GetSingleUserViaTokenHandler(IUserRepository users, IDecrypter decrypter)
    {
        _users = users;
        _decrypter = decrypter;
    }

    public async Task<UserViewModel> Handle(GetSingleUserViaToken request, CancellationToken cancellationToken)
    {
        var userId = await _decrypter.DecryptFromBase64(request.Token);
        var user = await _users.GetByIdAsync(new Guid(userId));

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