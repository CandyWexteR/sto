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
    private readonly IIdGenerator _idGenerator;

    public InventoryService(IInventoryItemRepository repos, IIdGenerator idGenerator)
    {
        _repos = repos;
        _idGenerator = idGenerator;
    }

    public async Task<InventoryItemFullViewModel> Get(Guid id)
    {
        var item = await _repos.GetByIdAsync(id) ?? throw new Exception();
        return new InventoryItemFullViewModel()
        {
            Id = item.Id,
            Name =  item.Name,
            Bought =  item.Bought,
            Description =  item.Description,
            BoughtUnit =  item.BoughtUnit,
            PriceUnits =  item.PriceUnits,
            SerialNumber =  item.SerialNumber,
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
            model.BoughtUnit);

        await _repos.UpdateAsync(item);
    }

    public Task Remove(Guid id)
    {
        return _repos.RemoveAsync(id);
    }
}