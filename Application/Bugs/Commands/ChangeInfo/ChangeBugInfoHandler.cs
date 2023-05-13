using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.Bugs.Commands.ChangeInfo;

public class ChangeBugInfoHandler : ICommandHandler<ChangeBugInfo>
{
    private readonly IBugsRepository _repos;
    private const string NotFoundMessage = "Указанный дефект не был найден";

    public ChangeBugInfoHandler(IBugsRepository repos)
    {
        _repos = repos;
    }

    public async Task Handle(ChangeBugInfo request, CancellationToken cancellationToken)
    {
        var bug = await _repos.GetByIdAsync(request.Id);

        bug.ThrowIfNull(NotFoundMessage);
        bug?.UpdateInfo(request.Title, request.Description, bug.CompletedAt);
        await _repos.UpdateAsync(bug);
    }
}