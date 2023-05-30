using Application.CQRS;

namespace Application.Vehicles.Queries.GetSingle;

public class GetSingleRole : IQuery<VehicleViewModel>
{
    public Guid RoleId { get; set; }
}