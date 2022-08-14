#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using Microsoft.Extensions.DependencyInjection;
using System;
using TinyIoC;
using static TinyIoC.TinyIoCContainer;

namespace HatTrick.DbEx.Sql.Configuration
{
    internal class TinyIoCServiceCollectionAdapter : IServiceCollectionAdapter
    {
        #region internals
        private readonly IServiceCollection _services;
        private readonly TinyIoCContainer _container;
        #endregion

        #region constructors
        public TinyIoCServiceCollectionAdapter(IServiceCollection services, TinyIoCContainer container)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _container = container ?? throw new ArgumentNullException(nameof(container));
        }
        #endregion

        #region methods
        public void AdaptServiceDescriptors()
        {
            foreach (var descriptor in _services)
                ConvertServiceDescriptor(descriptor);
        }

        private void ConvertServiceDescriptor(ServiceDescriptor descriptor)
        {
            switch (descriptor.Lifetime)
            {
                case ServiceLifetime.Singleton: ConvertSingletonServiceDescriptor(descriptor); break;
                case ServiceLifetime.Transient: ConvertTransientServiceDescriptor(descriptor); break;
                default: throw new NotImplementedException($"Service lifetime {descriptor.Lifetime} is not supported.");
            };
        }

        private void ConvertSingletonServiceDescriptor(ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance is not null)
                RegisterInstance(descriptor.ServiceType, descriptor.ImplementationInstance);
            else if (descriptor.ImplementationFactory is not null)
                RegisterFactory(descriptor.ServiceType, descriptor.ImplementationFactory, o => o.AsSingleton());
            else if (descriptor.ImplementationType is not null)
                RegisterType(descriptor.ServiceType, descriptor.ImplementationType, o => o.AsSingleton());
            else throw new DbExpressionConfigurationException($"Could not determine correct method to register the singleton service by the provided descriptor {descriptor}.");
        }

        private void ConvertTransientServiceDescriptor(ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance is not null)
                RegisterInstance(descriptor.ServiceType, descriptor.ImplementationInstance, o => o.AsMultiInstance());
            else if (descriptor.ImplementationFactory is not null)
                RegisterFactory(descriptor.ServiceType, descriptor.ImplementationFactory);
            else if (descriptor.ImplementationType is not null)
                RegisterType(descriptor.ServiceType, descriptor.ImplementationType, o => o.AsMultiInstance());
            else throw new DbExpressionConfigurationException($"Could not determine correct method to register the transient service by the provided descriptor {descriptor}.");
        }

        private void RegisterInstance(Type serviceType, object? instance, Action<RegisterOptions>? registerOptions = null)
        {
            try
            {
                var options = _container.Register(serviceType, instance);
                registerOptions?.Invoke(options);
            }
            catch (Exception e)
            {
                throw CreateConvertDescriptorFailedException(serviceType, e);
            }
        }

        private void RegisterFactory(Type serviceType, Func<IServiceProvider, object?> factory, Action<RegisterOptions>? registerOptions = null)
        {
            try
            {
                var options = _container.Register(serviceType, (c, o) =>
                {
                    return factory.Invoke(c);
                });
                registerOptions?.Invoke(options);
            }
            catch (Exception e)
            {
                throw CreateConvertDescriptorFailedException(serviceType, e);
            }
        }

        private void RegisterType(Type serviceType, Type implementationType, Action<RegisterOptions>? registerOptions = null)
        {
            try
            {
                var options = _container.Register(serviceType, implementationType);
                registerOptions?.Invoke(options);
            }
            catch (Exception e)
            {
                throw CreateConvertDescriptorFailedException(serviceType, e);
            }
        }

        private static DbExpressionConfigurationException CreateConvertDescriptorFailedException(Type serviceType, Exception innerException)
            => new($"Could not register service {serviceType}, see inner exeption for details.", innerException);
        #endregion
    }
}
