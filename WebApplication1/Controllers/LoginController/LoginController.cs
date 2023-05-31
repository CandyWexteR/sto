using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Additonal;
using WebApplication1.Controllers.LoginController.Models;

namespace WebApplication1.Controllers.LoginController;

[Route("[controller]")]
public class LoginController : BaseController
{
    private readonly IHttpContextAccessor _accessor;

    public LoginController(IMediator mediator, IHttpContextAccessor accessor) : base(mediator)
    {
        _accessor = accessor;
    }

    [HttpGet]
    public async Task<IActionResult> GetLoginPage()
    {
        return View("LoginPage");
    }
    
    [HttpPost]
    public async Task<IActionResult> LogIn(LoginModel model)
    {
        var claims = new List<Claim>() { new Claim("authtoken", Guid.NewGuid().ToString("N")) };
        var identity = new ClaimsIdentity(claims);
        identity.Label = "user token identity label";
        _accessor.HttpContext.User = new ClaimsPrincipal(identity); 
        //_accessor.HttpContext.Session.SetString("token", "asd");
        
        return RedirectToAction();
    }
    
    
}