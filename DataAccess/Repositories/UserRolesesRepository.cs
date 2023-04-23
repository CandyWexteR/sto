using Core.Models.UserRoles;
using Core.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories;

public class UserRolesesRepository : RepositoryBase<UserRole>, IUserRolesRepository
{
    public UserRolesesRepository(DatabaseContext context) : base(context, context.UserRoles)
    {
    }
}