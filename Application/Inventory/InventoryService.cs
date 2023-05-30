using Application.IdGenerator;
using Application.Inventory.InputModels;
using Application.Inventory.ViewModels;
using Application.PagedResult;
using Core.Models.Inventory;
using Core.Repositories;

namespace Application.Inventory;

public class InventoryService : IInventoryService
{
    private readonly IInventoryItemRepository _repos;
    private readonly IInventoryItemAcceptabilityRepository _acceptabilityRepos;
    private readonly IVehiclesRepository _vehRepos;
    private readonly IIdGenerator _idGenerator;

    public InventoryService(IInventoryItemRepository repos, IIdGenerator idGenerator,
        IInventoryItemAcceptabilityRepository acceptabilityRepos, IVehiclesRepository vehRepos)
    {
        _repos = repos;
        _idGenerator = idGenerator;
        _acceptabilityRepos = acceptabilityRepos;
        _vehRepos = vehRepos;
    }

    public async Task<InventoryItemFullViewModel> Get(Guid id)
    {
        var item = await _repos.GetByIdAsync(id) ?? throw new Exception();
        return new InventoryItemFullViewModel()
        {
            Id = item.Id,
            Name = item.Name,
            Bought = item.Bought,
            Description = item.Description,
            BoughtUnit = item.BoughtUnit,
            PriceUnits = item.PriceUnits,
            SerialNumber = item.SerialNumber,
            Price = item.Price
        };
    }

    public async Task<PagedResult<InventoryItemShortViewModel>> GetPage(PagedResultInputModel model)
    {
        var all = await _repos.GetAllAsync();

        return all.Select(v => new InventoryItemShortViewModel()
            {
                Id = v.Id,
                Name = v.Name
            })
            .ToPagedResult(model);
    }

    public async Task<Guid> Create(InventoryItemInputModel model)
    {
        var id = _idGenerator.GenerateGuid();

        //Validation

        var item = InventoryItem.Create(id, model.Name, model.Description, model.Price, model.PriceUnits, model.Bought,
            model.BoughtUnit, model.SerialNumber);

        await _repos.AddAsync(item);

        return id;
    }

    public async Task ChangeInfo(Guid id, InventoryItemInputModel model)
    {
        var item = await _repos.GetByIdAsync(id) ?? throw new Exception("");

        item.ChangeInfo(model.Name, model.Description, model.Price, model.PriceUnits, model.Bought,
            model.BoughtUnit, model.SerialNumber);

        await _repos.UpdateAsync(item);
    }

    public Task Remove(Guid id)
    {
        return _repos.RemoveAsync(id);
    }

    public async Task AddAcceptability(Guid itemId, Guid vehId)
    {
        var acceptability =
            (await _acceptabilityRepos.GetAllAsync()).FirstOrDefault(v =>
                v.VehicleId == vehId && v.InventoryItemId == itemId);
        var vehicle = await _vehRepos.GetByIdAsync(vehId);
        var inventoryItem = await _repos.GetByIdAsync(itemId);

        if (acceptability == null && vehicle != null && inventoryItem != null)
        {
            var id = await _idGenerator.GenerateGuidAsync();
            var item = InventoryItemAcceptability.Create(id, itemId, vehId);
            await _acceptabilityRepos.AddAsync(item);
        }
    }

    public async Task RemoveAcceptability(Guid itemId, Guid vehId)
    {
        //TODO: message
        var acceptability =
            (await _acceptabilityRepos.GetAllAsync()).FirstOrDefault(v =>
                v.VehicleId == vehId && v.InventoryItemId == itemId) ?? throw new Exception();
        await _acceptabilityRepos.RemoveAsync(acceptability.Id);
    }

    public Task RemoveAcceptability(Guid acceptAbilityId)
    {
        return _acceptabilityRepos.RemoveAsync(acceptAbilityId);
    }
}