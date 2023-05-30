using Application.CQRS;
using Core.Extensions;
using Core.Repositories;

namespace Application.Vehicles.Queries.GetSingle;

public class GetSingleRoleHandler : IQueryHandler<GetSingleRole, VehicleViewModel>
{
    private readonly IVehiclesRepository _repos;

    public GetSingleRoleHandler(IVehiclesRepository repos)
    {
        _repos = repos;
    }

    public async Task<VehicleViewModel> Handle(GetSingleRole request, CancellationToken cancellationToken)
    {
        var userRole = await _repos.GetByIdAsync(request.RoleId);

        userRole.ThrowIfNull();
        
        return new VehicleViewModel()
        {
            Id = userRole.Id,
            Name = userRole.Name,
            Model = userRole.Model
        };
    }
}