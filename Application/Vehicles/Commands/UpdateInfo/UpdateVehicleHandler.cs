using Application.CQRS;
using Core.Extensions;
using Core.Models.Vehicles;
using Core.Repositories;

namespace Application.Vehicles.Commands.UpdateInfo;

public class UpdateVehicleHandler : ICommandHandler<UpdateVehicle>
{
    private readonly IVehiclesRepository _vehicles;

    public UpdateVehicleHandler(IVehiclesRepository vehicles)
    {
        _vehicles = vehicles;
    }

    public async Task Handle(UpdateVehicle request, CancellationToken cancellationToken)
    {
        var veh = await _vehicles.GetByIdAsync(request.Id);
        veh.ThrowIfNull();

        var newVeh = Vehicle.Create(request.Id, request.Name, request.Model);
        await _vehicles.UpdateAsync(newVeh);
    }
}