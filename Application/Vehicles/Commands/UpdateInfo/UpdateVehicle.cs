using Application.CQRS;

namespace Application.Vehicles.Commands.UpdateInfo;

public class UpdateVehicle : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
}