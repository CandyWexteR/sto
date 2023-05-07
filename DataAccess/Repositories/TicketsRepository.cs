using Core.Models.Tickets;
using Core.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class TicketsRepository : RepositoryBase<Ticket>, ITicketsRepository
{
    public TicketsRepository(DatabaseContext context) : base(context, context.Tickets)
    {
    }
}