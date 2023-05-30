using Application.Bugs.Queries.ViewModels;
using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.Bugs.Queries.Single;

public class GetByIdHandler : IQueryHandler<GetById, BugFullViewModel>
{
    private readonly IBugsRepository _repos;
    private readonly IUsedInventoryItemRepository _usedInventoryItemRepository;
    private const string NotFoundMessage = "Указанный дефект не был найден";

    public GetByIdHandler(IBugsRepository repos, IUsedInventoryItemRepository usedInventoryItemRepository)
    {
        _repos = repos;
        _usedInventoryItemRepository = usedInventoryItemRepository;
    }

    public async Task<BugFullViewModel> Handle(GetById request, CancellationToken cancellationToken)
    {
        var bug = await _repos.GetByIdAsync(request.Id);

        bug.ThrowIfNull(NotFoundMessage);

        var allItems = await _usedInventoryItemRepository.GetAllAsync();
        var items = allItems.Where(v => v.BugId == bug.Id).Select(v => v.InventoryItemId).ToList();

        return new BugFullViewModel()
        {
            Id = bug.Id,
            Description = bug.Description,
            Title = bug.Title,
            CompletedAt = bug.CompletedAt,
            TicketId = bug.TicketId,
            CreatedAt = bug.CreatedAt,
            UsedInventoryItems = items
        };
    }
}