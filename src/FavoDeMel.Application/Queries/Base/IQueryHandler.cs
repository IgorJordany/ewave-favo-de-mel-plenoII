using System.Threading.Tasks;

namespace FavoDeMel.Application.Queries.Base
{
    public interface IQueryHandler <TRequest, TResponse> 
        : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
    }

    public interface IRequestHandler<in TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}