using System.Security.Claims;
using Application.Users.Commands.UpdateUserToken;
using Application.Users.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Additonal;
using WebApplication1.Controllers.LoginController.Models;

namespace WebApplication1.Controllers.LoginController;

[Route("[controller]")]
public class LoginController : BaseController
{
    private readonly IHttpContextAccessor _accessor;

    public LoginController(IMediator mediator, IHttpContextAccessor accessor) 
        : base(mediator, accessor)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetLoginPage()
    {
        return View("LoginPage");
    }

    [HttpPost]
    public async Task<IActionResult> LogIn(LoginModel model)
    {
        var getUserModel = new GetUserViaLoginPassword()
        {
            Username = model.Username,
            Password = model.Password
        };

        var user = await _mediator.Send(getUserModel);

        var updateTokenCommand = new UpdateUserToken()
        {
            Id = user.Id
        };

        await _mediator.Send(updateTokenCommand);
        
        user = await _mediator.Send(getUserModel);

        await SetUserToken(user);

        return RedirectToAction("My", "User");
    }
}