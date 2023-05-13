using Application.CQRS;
using Application.IdGenerator;
using Application.TimeProvider;
using Core.Extensions;
using Core.Models.Bugs;
using Core.Repositories;

namespace Application.Bugs.Commands.MarkCompleted;

public class MarkCompletedHandler : ICommandHandler<MarkCompleted>
{
    private readonly IBugsRepository _repos;
    private readonly IUsedInventoryItemRepository _usedInventoryItemRepository;
    private readonly IInventoryItemRepository _inventoryItemRepository;
    private readonly ITimeProvider _timeProvider;
    private readonly IIdGenerator _gen;

    private const string NotFoundMessage = "Указанный дефект не был найден";

    public MarkCompletedHandler(IBugsRepository repos, IUsedInventoryItemRepository usedInventoryItemRepository,
        IInventoryItemRepository inventoryItemRepository, ITimeProvider timeProvider, IIdGenerator gen)
    {
        _repos = repos;
        _usedInventoryItemRepository = usedInventoryItemRepository;
        _inventoryItemRepository = inventoryItemRepository;
        _timeProvider = timeProvider;
        _gen = gen;
    }

    public async Task Handle(MarkCompleted request, CancellationToken cancellationToken)
    {
        var bug = await _repos.GetByIdAsync(request.Id);
        bug.ThrowIfNull(NotFoundMessage);
        var time = await _timeProvider.GetCurrentDateTimeAsync();

        bug.UpdateInfo(bug.Title, bug.Description, time);

        var allItems = await _inventoryItemRepository.GetAllAsync();

        if (!allItems.ContainsAll(request.UsedInventoryItems))
        {
            throw new Exception("Не найдены указанные элементы инвентаря");
        }

        var usedItems = request.UsedInventoryItems.Select(inventoryItemId =>
            UsedInventoryItem.Create(_gen.GenerateGuid(), inventoryItemId, bug.Id)).ToArray();

        await _repos.UpdateAsync(bug);
        await _usedInventoryItemRepository.AddRangeAsync(usedItems);
    }
}