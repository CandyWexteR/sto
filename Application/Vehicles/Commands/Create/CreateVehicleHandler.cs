using Application.CQRS;
using Core.Models.Vehicles;
using Core.Repositories;

namespace Application.Vehicles.Commands.Create;

public class CreateVehicleHandler : ICommandHandler<CreateVehicle>
{
    private readonly IVehiclesRepository _vehicles;

    public CreateVehicleHandler(IVehiclesRepository vehicles)
    {
        _vehicles = vehicles;
    }

    public Task Handle(CreateVehicle request, CancellationToken cancellationToken) =>
        _vehicles.AddAsync(Vehicle.Create(request.Id, request.Name, request.Model));
}