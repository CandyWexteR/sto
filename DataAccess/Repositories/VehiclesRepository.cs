using Core.Models.Vehicles;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class VehiclesRepository : RepositoryBase<Vehicle>, IVehiclesRepository
{
    public VehiclesRepository(DatabaseContext context) : base(context, context.Vehicles)
    {
    }
}