using Core.Models.Users;
using Core.Repositories;
using DataAccess.Context;

namespace DataAccess.Repositories;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(DatabaseContext context) : base(context, context.Users)
    {
    }
}