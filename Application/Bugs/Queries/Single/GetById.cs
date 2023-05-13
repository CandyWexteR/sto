using Application.Bugs.ViewModels;
using Application.CQRS;

namespace Application.Bugs.Queries.Single;

public class GetById : IQuery<BugFullViewModel>
{
    public Guid Id { get; set; }
}