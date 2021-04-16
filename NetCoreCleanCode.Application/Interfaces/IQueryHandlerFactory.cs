namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandlerFactory
    {
        IQueryHandler<TQuery> CreateQueryHandler<TQuery>();
    }
}