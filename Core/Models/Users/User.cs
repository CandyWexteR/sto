using Newtonsoft.Json;

namespace Core.Models.Users;

public class User : IdableEntity
{
    [JsonConstructor]
    public User(Guid id, string username, string firstName, string lastName, string? middleName, Guid userRoleId, 
        string passwordHash, string? email)
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        UserRoleId = userRoleId;
        PasswordHash = passwordHash;
        Email = email;
    }

    public Guid Id { get; protected set; }
    public string Username { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string? MiddleName { get; protected set; }
    public Guid UserRoleId { get; protected set; }
    public string PasswordHash { get; protected set; }
    public string? Email { get; protected set; }

    public static User Create(Guid id, string username, string firstName, string lastName, string? middleName,
        Guid userRole, string passwordHash, string? email)
    {
        //TODO: Проверки
        
        return new User(id, username, firstName, lastName, middleName, userRole, passwordHash, email);
    }

    public void ChangeInfo(string username, string firstName, string lastName, string? middleName, Guid userRole, 
        string passwordHash, string? email)
    {
        //TODO: Проверки
        
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        UserRoleId = userRole;
        PasswordHash = passwordHash;
        Email = email;
    }
}