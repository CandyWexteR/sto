using Application.CQRS;

namespace Application.Vehicles.Commands.Remove;

public class RemoveVehicle : ICommand
{
    public Guid Id { get; set; }
}