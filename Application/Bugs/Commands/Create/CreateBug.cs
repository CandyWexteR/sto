using Application.Bugs.InputModels;
using Application.CQRS;

namespace Application.Bugs.Commands.Create;

public class CreateBug : BugInputModel, ICommand
{
    public Guid Id { get; set; }
}