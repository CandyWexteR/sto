using Application.Bugs.InputModels;
using Application.Bugs.Queries.ViewModels;
using Application.PagedResult;

namespace Application.Bugs;

public interface IBugs
{
    public Task<PagedResult<BugShortViewModel>> GetPaged(PagedResultInputModel model);
    public Task<BugFullViewModel> GetById(Guid id);
    public Task<Guid> AddBug(BugInputModel model);
    public Task ChangeBugInfo(Guid id, BugInputModel model);
    public Task MarkBugCompleted(Guid id, List<Guid> usedInventoryItems);
}