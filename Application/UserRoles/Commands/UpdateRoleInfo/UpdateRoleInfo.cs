using Application.CQRS;
using Core.Models.UserRoles;

namespace Application.UserRoles.Commands.UpdateRoleInfo;

public class UpdateRoleInfo : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AccessLevel Users { get; set; }
    public AccessLevel Inventory { get; set; }
    public AccessLevel ComponentsOrderings { get; set; }
    public AccessLevel ServiceOrders { get; set; }
    public AccessLevel Docs { get; set; }
    public AccessLevel Bugs { get; set; }
    public AccessLevel Vehicles { get; set; }
}