namespace NetCoreCleanCode.Domain.Extensions
{
    public static class ObjectExtensions
    {
        public static T InvokeMethod<T>(this object caller, string name, params object[] parameters)
        {
            var method = caller?.GetType()?.GetMethod(name);
                
            return (T)method?.Invoke(caller, parameters);
        }
    }
}