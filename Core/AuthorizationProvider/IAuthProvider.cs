using Core.Models.Users;

namespace Core.AuthorizationProvider;

public interface IAuthProvider
{
    public Task Authenticate(string username, string password);
    public Task<bool> IsAuthenticated();
    public Task<string> GetUsername();
    public Task<string> GetToken();
    public Task<User> GetUser();
}