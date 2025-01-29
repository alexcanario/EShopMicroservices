using MediatR;

namespace EShop.BuildingBlocks.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse> where TResponse : notnull
{

}