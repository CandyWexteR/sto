using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Application.Jobs;

public class MigrateJob : IJob
{
    private readonly DatabaseContext _context;

    public MigrateJob(DatabaseContext context)
    {
        _context = context;
    }

    public Task Execute(IJobExecutionContext context)
    {
        return _context.Database.MigrateAsync();
    }
}