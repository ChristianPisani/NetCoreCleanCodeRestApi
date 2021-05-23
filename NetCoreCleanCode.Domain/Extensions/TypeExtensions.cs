using System;
using System.Linq;

namespace NetCoreCleanCode.Domain.Extensions
{
    public static class TypeExtensions
    {
        public static Type ImplementsGenericInterface(this Type assemblyType, Type interfaceType, Type typeArgument)
        {
            var interfaces = assemblyType?.GetInterfaces();
            var interfacesFilteredByName = interfaces?.Where(i => i.Name == interfaceType.Name);
            return interfacesFilteredByName
                ?.FirstOrDefault(i => i.GenericTypeArguments
                    .Any(genericTypeArgument => genericTypeArgument?.Name == typeArgument.Name));
        }
        
        public static bool ImplementsInterface(this Type assemblyType, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
            {
                return false;
                //throw new Exception("Can only check implementation of interfaces");
            }
            
            var interfaces = assemblyType.GetInterfaces();
            var implementsInterface = interfaces.Any(i => i.Name == interfaceType.Name);

            return implementsInterface;
        }
    }
}