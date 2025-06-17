using MediatR;

namespace EShop.BuildingBlocks.CQRS;

public interface IQuery<out TResult> : IRequest<TResult> 
    where TResult : notnull
{

}