using Application.CQRS;
using Application.IdGenerator;
using Core.Extensions;
using Core.Repositories;

namespace Application.Users.Commands.UpdateUserToken;

public class UpdateUserTokenHandler : ICommandHandler<UpdateUserToken>
{
    private readonly IUserRepository _repository;
    private readonly IIdGenerator _generator;

    public UpdateUserTokenHandler(IUserRepository repository, IIdGenerator generator)
    {
        _repository = repository;
        _generator = generator;
    }

    public async Task Handle(UpdateUserToken request, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(request.Id);

        user.ThrowIfNull("Не найден указанный пользователь");
        
        user.UpdateToken(await _generator.GenerateGuidAsync(), await _generator.GenerateGuidAsync());

        await _repository.UpdateAsync(user);
    }
}