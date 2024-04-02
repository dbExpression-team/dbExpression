using DbExpression.Sql;
using DbExpression.Sql.Configuration;
using System;

namespace TinyIoC
{
    partial class TinyIoCContainer<TDatabase> : TinyIoCContainer, IServiceProvider<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {

    }

    partial class TinyIoCContainer : IServiceProvider
    {
        public object? GetService(Type serviceType)
        {
            if (TryResolve(serviceType, out object service))
            {
                return service;
            }
            return null;
        }

        public bool IsRegistered<T>()
            where T : class
            => IsRegistered(typeof(T));

        public bool IsRegistered(Type type)
           => _RegisteredTypes.ContainsKey(type);

        private bool TryResolveFromRoot(Type serviceType, out object? service)
        {
            service = Resolve<IServiceProvider>().GetService(serviceType);
            return service is not null;
        }
    }
}