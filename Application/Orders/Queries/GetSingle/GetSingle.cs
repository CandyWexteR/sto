using Application.CQRS;
using Application.Orders.ViewModels;

namespace Application.Orders.Queries.GetSingle;

public class GetSingle: IQuery<OrderViewModel>
{
    public Guid Id { get; set; }
}