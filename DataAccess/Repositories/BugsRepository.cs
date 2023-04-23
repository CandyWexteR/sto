using Core.Models.Bugs;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class BugsRepository : RepositoryBase<Bug>, IBugsRepository
{
    public BugsRepository(DatabaseContext context) : base(context, context.Bugs)
    {
    }
}