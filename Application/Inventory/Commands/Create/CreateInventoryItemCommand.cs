using Application.CQRS;

namespace Application.Inventory.Commands.Create;

public class CreateInventoryItemCommand : ICommand
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string SerialNumber { get; set; }
    public ulong Price { get; set; }
    public string PriceUnits { get; set; }
    public ulong Bought { get; set; }
    public string BoughtUnit { get; set; }
}