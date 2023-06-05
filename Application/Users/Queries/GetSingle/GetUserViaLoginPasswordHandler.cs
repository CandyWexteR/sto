using Application.CQRS;
using Core.Encryption;
using Core.Extensions;
using Core.Models.Users;
using Core.Repositories;

namespace Application.Users.Queries.GetSingle;

public class GetUserViaLoginPasswordHandler : IQueryHandler<GetUserViaLoginPassword, User>
{
    private readonly IUserRepository _users;
    private readonly IEncrypter _encrypter;

    public GetUserViaLoginPasswordHandler(IUserRepository users, IEncrypter encrypter)
    {
        _users = users;
        _encrypter = encrypter;
    }

    public async Task<User> Handle(GetUserViaLoginPassword request, CancellationToken cancellationToken)
    {
        var allUsers = await _users.GetAllAsync();
        var current = allUsers.FirstOrDefault(v=>v.Username == request.Username);
        
        current.ThrowIfNull("Не найден пользователь");
        
        var passwordEncrypted = await _encrypter.EncryptToBase64(request.Password);

        return current.PasswordHash == passwordEncrypted
            ? current 
            : throw new Exception("Ошибка входа, проверьте логин и пароль");
    }
}