using Application.CQRS;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.UserRoles.Queries.GetSingle;

public class GetSingleRole : IQuery<RoleViewModel>
{
    public Guid RoleId { get; set; }
}