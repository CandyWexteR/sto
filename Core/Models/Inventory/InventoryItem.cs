using Core.Extensions;
using Newtonsoft.Json;

namespace Core.Models.Inventory;

public class InventoryItem : IdableEntity
{
    [JsonConstructor]
    private InventoryItem(Guid id, string name, string description, ulong price, string priceUnits, ulong bought,
        string boughtUnit, string serialNumber)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        PriceUnits = priceUnits;
        Bought = bought;
        BoughtUnit = boughtUnit;
        SerialNumber = serialNumber;
    }

    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Description { get; protected set; }
    public string SerialNumber { get; set; }
    public ulong Price { get; protected set; }
    public string PriceUnits { get; protected set; }
    public ulong Bought { get; protected set; }
    public string BoughtUnit { get; protected set; }
    

    public static InventoryItem Create(Guid id, string name, string description, ulong price, string priceUnits,
        ulong bought,
        string boughtUnit, string serialNumber)
    {
        //TODO: В валидацию добавить серийный номер
        ValidateValues(name, description, price, priceUnits, bought, boughtUnit);

        return new InventoryItem(id, name, description, price, priceUnits, bought, boughtUnit, serialNumber);
    }

    private static void ValidateValues(string name, string description, ulong price, string priceUnits, ulong bought,
        string boughtUnit)
    {
        var list = new List<Exception>();

        list.ThrowIfAny();
    }

    public void ChangeInfo(string name, string description, ulong price, string priceUnits, ulong bought,
        string boughtUnit)
    {
        ValidateValues(name, description, price, priceUnits, bought, boughtUnit);
        
        Name = name;
        Description = description;
        Price = price;
        PriceUnits = priceUnits;
        Bought = bought;
        BoughtUnit = boughtUnit;
    }
}