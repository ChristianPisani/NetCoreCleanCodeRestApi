namespace NetCoreCleanCode.Application.Interfaces
{
    public interface IQueryHandlerFactory
    {
        object CreateQueryHandler<TOut>(IQuery<TOut> queryType);
    }
}