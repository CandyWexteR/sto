using Core.Models.Bugs;

namespace Application.Bugs.ViewModels;

public class BugFullViewModel
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public List<Guid> UsedInventoryItems { get; set; }
}