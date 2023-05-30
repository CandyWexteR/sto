using Application.CQRS;
using Application.PagedResult;

namespace Application.Vehicles.Queries.GetPage;

public class GetRolesPage : PagedResultInputModel, IQuery<PagedResult<VehicleShortViewModel>>
{
    
}