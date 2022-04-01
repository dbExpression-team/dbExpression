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

using HatTrick.DbEx.Sql;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public class DatabaseServiceCollectionDecorator<TDatabase> : ISqlDatabaseRuntimeServiceCollection<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        private readonly ServiceLifetime lifetime;
        #endregion

        #region constructors
        public DatabaseServiceCollectionDecorator(IServiceCollection services, ServiceLifetime lifetime)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
            this.lifetime = lifetime;
        }
        #endregion

        #region methods
        #region AddScoped
        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped(Type serviceType)
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var wrapped = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), serviceType, serviceType);
            services.AddScoped(wrapped, wrapped);
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), serviceType);
            services.AddScoped(databaseServiceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, sp, implementationFactory));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped(Type serviceType, Type implementationType)
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var databaseImplementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), serviceType, implementationType);
            services.AddScoped(databaseServiceType, databaseImplementationType);
            services.AddScoped(implementationType);
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService>() where TService : class
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), typeof(TService), typeof(TService));
            services.AddScoped(serviceType, implementationType);
            services.AddScoped(typeof(TService));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService>(Func<IServiceProvider, TService> implementationFactory) 
            where TService : class
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.TryAddScoped(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, sp, implementationFactory));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService, TImplementation>() 
            where TService : class 
            where TImplementation : class, TService
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), typeof(TService), typeof(TImplementation));
            services.AddScoped(serviceType, implementationType);
            services.AddScoped(typeof(TImplementation));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) 
            where TService : class 
            where TImplementation : class, TService
        {
            if (lifetime < ServiceLifetime.Scoped)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.AddScoped(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, implementationFactory));
            return this;
        }
        #endregion

        #region AddSingleton
        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType)
        {
            var wrapped = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), serviceType, serviceType);
            services.AddSingleton(wrapped, wrapped);
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), serviceType);
            services.AddSingleton(databaseServiceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, sp, implementationFactory));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType, object implementationInstance)
        {
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), serviceType);
            services.AddSingleton(databaseServiceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, implementationInstance));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType, Type implementationType)
        {
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var databaseImplementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), serviceType, implementationType);
            services.AddSingleton(databaseServiceType, databaseImplementationType);
            services.AddSingleton(implementationType);
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService>()
            where TService : class
        {
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), typeof(TService), typeof(TService));
            services.AddSingleton(serviceType, implementationType);
            services.AddSingleton(typeof(TService));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService>(Func<IServiceProvider, TService> implementationFactory)
            where TService : class
        {
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.AddSingleton(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, sp, implementationFactory));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService>(TService implementationInstance)
            where TService : class
        {
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.AddSingleton(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, implementationInstance));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService
        {
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), typeof(TService), typeof(TImplementation));
            services.AddSingleton(serviceType, implementationType);
            services.AddSingleton(typeof(TImplementation));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory)
            where TService : class 
            where TImplementation : class, TService
        {
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.AddSingleton(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, implementationFactory));
            return this;
        }
        #endregion

        #region AddTransient
        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient(Type serviceType)
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var wrapped = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), serviceType, serviceType);
            services.AddTransient(wrapped, wrapped);
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient(Type serviceType, Func<IServiceProvider, object> implementationFactory)
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), serviceType);
            services.AddTransient(databaseServiceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, sp, implementationFactory));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient(Type serviceType, Type implementationType)
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var databaseServiceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), serviceType);
            var databaseImplementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), serviceType, implementationType);
            services.AddTransient(databaseServiceType, databaseImplementationType);
            services.AddTransient(implementationType);
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService>() 
            where TService : class
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), typeof(TService), typeof(TService));
            services.AddTransient(serviceType, implementationType);
            services.AddTransient(typeof(TService));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService>(Func<IServiceProvider, TService> implementationFactory) 
            where TService : class
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.AddTransient(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, sp, implementationFactory));
            return this;
        }
        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService, TImplementation>() 
            where TService : class 
            where TImplementation : class, TService
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseService<,,>).MakeGenericType(typeof(TDatabase), typeof(TService), typeof(TImplementation));
            services.AddTransient(serviceType, implementationType);
            services.AddTransient(typeof(TImplementation));
            return this;
        }

        public ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) 
            where TService : class 
            where TImplementation : class, TService
        {
            if (lifetime < ServiceLifetime.Transient)
                throw new DbExpressionConfigurationException($"Service must have a service lifetime greater than or equal to {lifetime} to avoid captive dependencies.");
            var serviceType = typeof(DatabaseService<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            var implementationType = typeof(DatabaseServiceFactory<,>).MakeGenericType(typeof(TDatabase), typeof(TService));
            services.AddTransient(serviceType, sp => ActivatorUtilities.CreateInstance(sp, implementationType, implementationFactory));
            return this;
        }
        #endregion
        #endregion
    }
}
