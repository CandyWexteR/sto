using Application.CQRS;

namespace Application.Vehicles.Commands.Create;

public class CreateVehicle : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
}