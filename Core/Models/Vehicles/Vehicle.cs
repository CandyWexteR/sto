using Newtonsoft.Json;

namespace Core.Models.Vehicles;

public class Vehicle : IdableEntity
{
    [JsonConstructor]
    private Vehicle(Guid id, string name, string model)
    {
        Id = id;
        Name = name;
        Model = model;
    }
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Model { get; protected set; }

    public static Vehicle Create(Guid id, string name, string model)
    {
        return new Vehicle(id, name, model);
    }
}