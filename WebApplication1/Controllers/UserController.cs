using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class UserController : BaseController
{
    public UserController(IMediator mediator, IHttpContextAccessor accessor) 
        : base(mediator, accessor)
    {
    }

    [HttpGet]
    public async Task<IActionResult> My()
    {
        var user = await GetUser();
        return View("My");
    }
}