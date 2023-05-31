using Application.Users.Queries.GetSingle;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class BaseController : Controller
{
    protected readonly IMediator _mediator;

    protected BaseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    protected Task<UserViewModel> GetUser()
    {
        var contextToken = HttpContext.User.Claims.FirstOrDefault(v => v.Type == "token");

        var user = new GetSingleUserViaToken()
        {
            Token = contextToken.Value
        };
        return _mediator.Send(user);
    }
}