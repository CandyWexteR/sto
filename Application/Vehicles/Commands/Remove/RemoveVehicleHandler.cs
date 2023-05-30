using Application.CQRS;
using Application.Vehicles.Commands.Create;
using Core.Models.Vehicles;
using Core.Repositories;

namespace Application.Vehicles.Commands.Remove;

public class RemoveVehicleHandler : ICommandHandler<RemoveVehicle>
{
    private readonly IVehiclesRepository _vehicles;

    public RemoveVehicleHandler(IVehiclesRepository vehicles)
    {
        _vehicles = vehicles;
    }

    public Task Handle(RemoveVehicle request, CancellationToken cancellationToken) =>
        _vehicles.RemoveAsync(request.Id);
}