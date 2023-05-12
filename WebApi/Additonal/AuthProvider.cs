using System.Security.Claims;
using Core.AuthorizationProvider;
using Core.Encryption;
using Core.Models.Users;
using Core.Repositories;

namespace WebApi.Additonal;

public class AuthProvider : IAuthProvider
{
    private readonly IHttpContextAccessor _accessor;
    private readonly IEncrypter _encrypter;
    private readonly IDecrypter _decrypter;
    private readonly IUserRepository _userRepository;

    public AuthProvider(IHttpContextAccessor accessor, IEncrypter encrypter, IUserRepository userRepository,
        IDecrypter decrypter)
    {
        _accessor = accessor;
        _encrypter = encrypter;
        _userRepository = userRepository;
        _decrypter = decrypter;
    }

    protected HttpContext? Context => _accessor.HttpContext;

    public async Task Authenticate(string username, string password)
    {
        var users = await _userRepository.GetAllAsync();
        var user = users.FirstOrDefault(v => v.Username == username);

        var token = await _encrypter.EncryptToBase64(user.Username);

        var context = Context;
        context.User = new SelfPrincipal(new []{new Claim("token", token)});
    }

    /// <summary>
    /// Check self auth
    /// </summary>
    /// <returns></returns>
    public async Task<bool> IsAuthenticated()
    {
        var userToken = await GetToken();
        var username = await GetUsername() ?? throw new Exception();
        var allUsers = await _userRepository.GetAllAsync();
        var user = allUsers.FirstOrDefault(v => v.Username == username);

        return user != null && user.AccessToken == userToken && user.AccessTokenExpirationDate > DateTime.Now;
    }

    public async Task<string?> GetUsername()
    {
        var token = await GetToken() ?? throw new Exception();
        return await _decrypter.DecryptFromBase64(token);
    }

    public async Task<string?> GetToken()
    {
        return Context.User.Claims.FirstOrDefault(v => v.Type == "token")?.Value;
    }

    public async Task<User> GetUser()
    {
        var username = await GetUsername() ?? throw new Exception();
        var allUsers = await _userRepository.GetAllAsync();
        return allUsers.FirstOrDefault(v => v.Username == username) ?? throw new Exception();
    }
}