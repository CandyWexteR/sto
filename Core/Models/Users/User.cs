using Application.Constants;
using Newtonsoft.Json;

namespace Core.Models.Users;

public class User : IdableEntity
{
    [JsonConstructor]
    public User(Guid id, string username, string firstName, string lastName, string? middleName, Guid userRoleId,
        string passwordHash, string? email, string accessToken, DateTime accessTokenExpirationDate, string refreshToken)
    {
        Id = id;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        UserRoleId = userRoleId;
        PasswordHash = passwordHash;
        Email = email;
        AccessToken = accessToken;
        AccessTokenExpirationDate = accessTokenExpirationDate;
        RefreshToken = refreshToken;
    }

    public Guid Id { get; protected set; }
    public string Username { get; protected set; }
    public string FirstName { get; protected set; }
    public string LastName { get; protected set; }
    public string? MiddleName { get; protected set; }
    public Guid UserRoleId { get; protected set; }
    public string PasswordHash { get; protected set; }
    public string? Email { get; protected set; }
    public string AccessToken { get; protected set; }
    public DateTime AccessTokenExpirationDate { get; protected set; }
    public string RefreshToken { get; protected set; }

    public static User Create(Guid id, string username, string firstName, string lastName, string? middleName,
        Guid userRole, string passwordHash, string? email, string accessToken, string refreshToken)
    {
        //TODO: Проверки

        return new User(id, username, firstName, lastName, middleName, userRole, passwordHash, email, accessToken,
            DateTime.MinValue.ToUniversalTime(), refreshToken);
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

    public void UpdateToken(Guid token, Guid refreshToken)
    {
        AccessToken = token.ToString(TokenType.GuidType);
        RefreshToken = refreshToken.ToString(TokenType.GuidType);
    }
}