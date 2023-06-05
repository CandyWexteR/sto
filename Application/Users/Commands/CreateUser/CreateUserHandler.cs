using Application.Constants;
using Application.CQRS;
using Application.IdGenerator;
using Core.Encryption;
using Core.Models.Users;
using Core.Repositories;

namespace Application.Users.Commands.CreateUser;

public class CreateUserHandler : ICommandHandler<CreateUser>
{
    private readonly IUserRepository _users;
    private readonly IIdGenerator _idGenerator;
    private readonly IEncrypter _encrypter;

    public CreateUserHandler(IUserRepository users, IEncrypter encrypter, IIdGenerator idGenerator)
    {
        _users = users;
        _encrypter = encrypter;
        _idGenerator = idGenerator;
    }

    public async Task Handle(CreateUser request, CancellationToken cancellationToken)
    {
        var passHash = await _encrypter.EncryptToBase64(request.Password);

        var token = await _idGenerator.GenerateGuidAsync();
        var refresh = await _idGenerator.GenerateGuidAsync();
        
        var user = User.Create(request.Id, request.UserName, request.FirstName, request.LastName,
            request.MiddleName, Guid.Empty, passHash, request.Email, token.ToString(TokenType.GuidType), refresh.ToString(TokenType.GuidType));
        
        await _users.AddAsync(user);
    }
}