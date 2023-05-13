using Application.IdGenerator;
using Application.TimeProvider;
using Core.Models.Bugs;
using Core.Repositories;
using MediatR;

namespace Application.Bugs.Commands.Create;

public class CreateBugHandler : IRequestHandler<CreateBug>
{
    private readonly IBugsRepository _repos;
    private readonly ITimeProvider _timeProvider;
    private readonly IIdGenerator _gen;

    public CreateBugHandler(IIdGenerator gen, ITimeProvider timeProvider, IBugsRepository repos)
    {
        _gen = gen;
        _timeProvider = timeProvider;
        _repos = repos;
    }

    public async Task Handle(CreateBug request, CancellationToken cancellationToken)
    {
        var time = await _timeProvider.GetCurrentDateTimeAsync();
        var bug = Bug.Create(request.Id, request.TicketId, request.Title, request.Description, time, null);
        await _repos.AddAsync(bug);
    }
}