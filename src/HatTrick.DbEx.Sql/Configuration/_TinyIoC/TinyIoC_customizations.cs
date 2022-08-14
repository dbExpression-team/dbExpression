using System;

namespace TinyIoC
{
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

        private bool TryResolveFromRoot(Type serviceType, out object? service)
        {
            service = Resolve<IServiceProvider>().GetService(serviceType);
            return service is not null;
        }
    }
}