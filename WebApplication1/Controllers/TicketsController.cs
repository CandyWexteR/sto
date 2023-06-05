using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class TicketsController : BaseController
{
    public TicketsController(IMediator mediator, IHttpContextAccessor accessor) 
        : base(mediator, accessor)
    {
    }
    
    
}