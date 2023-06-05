using Application.IdGenerator;
using Application.Orders.Queries.GetSingle;
using Application.Users.Commands.CreateUser;
using Application.Users.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class RegisterController : BaseController
{
    private readonly IIdGenerator _idGenerator;

    public RegisterController(IMediator mediator, IIdGenerator idGenerator, IHttpContextAccessor accessor) 
        : base(mediator, accessor)
    {
        _idGenerator = idGenerator;
    }

    [HttpGet]
    public async Task<IActionResult> RegisterForm()
    {
        return View("Register");
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUser model)
    {
        model.Id = await _idGenerator.GenerateGuidAsync();
        await _mediator.Send(model);
        
        await SetUserToken(model.UserName, model.Password);
        return RedirectToAction("My", "User");
    }
}