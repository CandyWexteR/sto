using MediatR;

namespace Application.CQRS;

public interface IQuery<out T> : IRequest<T>
{
}