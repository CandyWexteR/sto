using Core.Models.UserRoles;

namespace Application.Users.Queries.GetSingle;

public class UserViewModel
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MiddleName { get; set; }
    public Guid UserRoleId { get; set; }
    public string PasswordHash { get; set; }
    public string? Email { get; set; }
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpirationDate { get; set; }
    public string RefreshToken { get; set; }
}