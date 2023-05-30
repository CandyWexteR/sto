using Application.Bugs.InputModels;
using Application.Bugs.Queries.ViewModels;
using Application.IdGenerator;
using Application.PagedResult;
using Application.TimeProvider;
using Core.Extensions;
using Core.Models.Bugs;
using Core.Repositories;

namespace Application.Bugs;

public class Bugs : IBugs
{
    private readonly IBugsRepository _repos;
    private readonly IUsedInventoryItemRepository _usedInventoryItemRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly ITimeProvider _timeProvider;
    private readonly IIdGenerator _gen;
    private const string NotFoundMessage = "Указанный дефект не был найден";

    public Bugs(IBugsRepository repos, ITimeProvider timeProvider, IIdGenerator gen,
        IUsedInventoryItemRepository usedInventoryItemRepository, IInventoryItemRepository inventoryItemRepository)
    {
        _repos = repos;
        _timeProvider = timeProvider;
        _gen = gen;
        _usedInventoryItemRepository = usedInventoryItemRepository;
        _inventoryItemRepository = inventoryItemRepository;
    }

    public async Task<PagedResult<BugShortViewModel>> GetPaged(PagedResultInputModel model)
    {
        var items = await _repos.GetAllAsync();

        return items.Select(v => new BugShortViewModel() { Id = v.Id, Title = v.Title }).ToPagedResult(model);
    }

    public async Task<BugFullViewModel> GetById(Guid id)
    {
        var bug = await _repos.GetByIdAsync(id);

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

    public async Task<Guid> AddBug(BugInputModel model)
    {
        var id = await _gen.GenerateGuidAsync();
        var time = await _timeProvider.GetCurrentDateTimeAsync();
        var bug = Bug.Create(id, model.TicketId, model.Title, model.Description, time, null);
        await _repos.AddAsync(bug);
        return id;
    }

    public async Task ChangeBugInfo(Guid id, BugInputModel model)
    {
        var bug = await _repos.GetByIdAsync(id);

        bug.ThrowIfNull(NotFoundMessage);
        bug?.UpdateInfo(model.Title, model.Description, bug.CompletedAt);
        await _repos.UpdateAsync(bug);
    }

    public async Task MarkBugCompleted(Guid id, List<Guid> usedInventoryItems)
    {
        var bug = await _repos.GetByIdAsync(id);
        bug.ThrowIfNull(NotFoundMessage);
        var time = await _timeProvider.GetCurrentDateTimeAsync();

        bug.UpdateInfo(bug.Title, bug.Description, time);

        var allItems = await _inventoryItemRepository.GetAllAsync();

        if (!allItems.ContainsAll(usedInventoryItems))
        {
            throw new Exception("Не найдены указанные элементы инвентаря");
        }

        var usedItems = usedInventoryItems.Select(inventoryItemId =>
            UsedInventoryItem.Create(_gen.GenerateGuid(), inventoryItemId, bug.Id)).ToArray();

        await _repos.UpdateAsync(bug);
        await _usedInventoryItemRepository.AddRangeAsync(usedItems);
    }
}