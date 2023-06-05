using System.Security.Claims;
using Application.Users.Queries.GetSingle;
using Core.Models.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class BaseController : Controller
{
    protected readonly IMediator _mediator;
    protected readonly IHttpContextAccessor _accessor;

    protected BaseController(IMediator mediator, IHttpContextAccessor accessor)
    {
        _mediator = mediator;
        _accessor = accessor;
    }

    protected Task<UserViewModel> GetUser()
    {
        var contextToken = HttpContext.User.Claims.FirstOrDefault(v => v.Type == "token")?.Value  
                           ?? (TempData["token"] as string);

        var user = new GetSingleUserViaToken()
        {
            Token = contextToken
        };
        return _mediator.Send(user);
    }

    protected async Task SetUserToken(string login, string password)
    {
        var user = await _mediator.Send(new GetUserViaLoginPassword()
        {
            Username = login,
            Password = password
        });

        await SetUserToken(user);
    }
    
    protected async Task SetUserToken(User user)
    {
        var claims = new List<Claim>() { new Claim("token", user.AccessToken) };
        TempData["token"] = user.AccessToken;
        
        var identity = new ClaimsIdentity(claims);
        
        _accessor.HttpContext.User = new ClaimsPrincipal(identity);
    }
}