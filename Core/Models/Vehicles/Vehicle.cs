namespace Core.Models.Vehicles;

public class Vehicle : IdableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Model { get; set; }
}