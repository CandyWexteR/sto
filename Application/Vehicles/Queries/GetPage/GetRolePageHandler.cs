using Application.CQRS;
using Application.PagedResult;
using Core.Repositories;

namespace Application.Vehicles.Queries.GetPage;

public class GetRolePageHandler : IQueryHandler<GetRolesPage,PagedResult<VehicleShortViewModel>>
{
    private readonly IUserRolesRepository _roles;

    public GetRolePageHandler(IUserRolesRepository roles)
    {
        _roles = roles;
    }

    public async Task<PagedResult<VehicleShortViewModel>> Handle(GetRolesPage request, CancellationToken cancellationToken)
    {
        var all = await _roles.GetAllAsync();
        var allView = all.Select(v => new VehicleShortViewModel()
        {
            Id = v.Id,
            Name = v.Name
        });

        return allView.ToPagedResult(request);
    }
}