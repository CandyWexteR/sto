using Application.Inventory.InputModels;
using Application.Inventory.ViewModels;
using Application.PagedResult;

namespace Application.Inventory;

public interface IInventoryService
{
    public Task<InventoryItemFullViewModel> Get(Guid id);
    public Task<PagedResult<InventoryItemShortViewModel>> GetPage(PagedResultInputModel model);
    public Task<Guid> Create(InventoryItemInputModel model);
    public Task ChangeInfo(Guid id, InventoryItemInputModel model);
    public Task Remove(Guid id);
}