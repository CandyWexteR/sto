using Core.Models.UserRoleAccessLevelRights;

namespace Core.Models.UserRoles;

public class UserRole : IdableEntity
{
    public UserRole(Guid id, string name, string description, AccessLevel users, AccessLevel inventory,
        AccessLevel componentsOrderings, AccessLevel serviceOrders, AccessLevel docs, AccessLevel bugs,
        AccessLevel vehicles)
    {
        Id = id;
        Name = name;
        Description = description;
        Users = users;
        Inventory = inventory;
        ComponentsOrderings = componentsOrderings;
        ServiceOrders = serviceOrders;
        Docs = docs;
        Bugs = bugs;
        Vehicles = vehicles;
    }

    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public AccessLevel Users { get; protected set; }
    public AccessLevel Inventory { get; protected set; }
    public AccessLevel ComponentsOrderings { get; protected set; }
    public AccessLevel ServiceOrders { get; protected set; }
    public AccessLevel Docs { get; protected set; }
    public AccessLevel Bugs { get; protected set; }

    public AccessLevel Vehicles { get; protected set; }
}