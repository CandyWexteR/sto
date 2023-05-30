using Application.CQRS;
using Application.PagedResult;
using Core.Repositories;

namespace Application.Users.Queries.GetPage;

public class GetUsersPageHandler : IQueryHandler<GetUsersPage,PagedResult<UserViewModel>>
{
    private readonly IUserRepository _users;

    public GetUsersPageHandler(IUserRepository users)
    {
        _users = users;
    }

    public async Task<PagedResult<UserViewModel>> Handle(GetUsersPage request, CancellationToken cancellationToken)
    {
        var all = await _users.GetAllAsync();
        var allView = all.Select(v => new UserViewModel()
        {
            Id = v.Id,
            FullName = $"{v.LastName} {v.FirstName}"
        });

        return allView.ToPagedResult(request);
    }
}