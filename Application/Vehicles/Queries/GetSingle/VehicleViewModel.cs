using Core.Models.UserRoles;

namespace Application.Vehicles.Queries.GetSingle;

public class VehicleViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
}