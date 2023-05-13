using Application.Bugs.InputModels;
using Application.CQRS;

namespace Application.Bugs.Commands.ChangeInfo;

public class ChangeBugInfo : BugInputModel, ICommand
{
    public Guid Id { get; set; }
}