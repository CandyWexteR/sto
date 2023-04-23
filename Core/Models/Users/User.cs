namespace Core.Models.Users;

public class User : IdableEntity
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public Guid UserRole { get; set; }
}