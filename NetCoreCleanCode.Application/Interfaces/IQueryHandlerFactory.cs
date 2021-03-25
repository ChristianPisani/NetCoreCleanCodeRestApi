namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery, TOut> CreateQueryHandler<TQuery, TOut>();
    }
}