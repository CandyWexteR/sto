using Application.CQRS;

namespace Application.Bugs.Commands.MarkCompleted;

public class MarkCompleted : ICommand
{
    public Guid Id { get; set; }
    public List<Guid> UsedInventoryItems { get; set; }
}