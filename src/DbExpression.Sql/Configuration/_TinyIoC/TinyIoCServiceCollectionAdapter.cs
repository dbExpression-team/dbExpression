﻿#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using Microsoft.Extensions.DependencyInjection;
using System;
using TinyIoC;
using static TinyIoC.TinyIoCContainer;

namespace DbExpression.Sql.Configuration
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
                case ServiceLifetime.Singleton: ConvertSingletonServiceDescriptor(descriptor); return;
                case ServiceLifetime.Transient: ConvertTransientServiceDescriptor(descriptor); return;
                default: DbExpressionConfigurationException.ThrowRegistrationAdapter(descriptor); return;
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
            else
                DbExpressionConfigurationException.ThrowRegistrationAdapter(descriptor);
        }

        private void ConvertTransientServiceDescriptor(ServiceDescriptor descriptor)
        {
            if (descriptor.ImplementationInstance is not null)
                RegisterInstance(descriptor.ServiceType, descriptor.ImplementationInstance, o => o.AsMultiInstance());
            else if (descriptor.ImplementationFactory is not null)
                RegisterFactory(descriptor.ServiceType, descriptor.ImplementationFactory);
            else if (descriptor.ImplementationType is not null)
                RegisterType(descriptor.ServiceType, descriptor.ImplementationType, o => o.AsMultiInstance());
            else
                DbExpressionConfigurationException.ThrowRegistrationAdapter(descriptor);
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
                DbExpressionConfigurationException.ThrowServiceRegistration(serviceType, serviceType, e);
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
                DbExpressionConfigurationException.ThrowServiceRegistration(serviceType, serviceType, e);
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
                DbExpressionConfigurationException.ThrowServiceRegistration(serviceType, implementationType, e);
            }
        }
        #endregion
    }
}
