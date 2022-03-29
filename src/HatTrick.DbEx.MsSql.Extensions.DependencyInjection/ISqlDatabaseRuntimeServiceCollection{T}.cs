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
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public interface ISqlDatabaseRuntimeServiceCollection<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped(Type serviceType);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped(Type serviceType, Func<IServiceProvider, object> implementationFactory);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped(Type serviceType, Type implementationType);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService>() where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService, TImplementation>() where TService : class where TImplementation : class, TService;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddScoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService;

        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType, Func<IServiceProvider, object> implementationFactory);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType, object implementationInstance);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton(Type serviceType, Type implementationType);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService>() where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService>(TService implementationInstance) where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService, TImplementation>() where TService : class where TImplementation : class, TService;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddSingleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService;

        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient(Type serviceType);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient(Type serviceType, Func<IServiceProvider, object> implementationFactory);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient(Type serviceType, Type implementationType);
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService>() where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService, TImplementation>() where TService : class where TImplementation : class, TService;
        ISqlDatabaseRuntimeServiceCollection<TDatabase> AddTransient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService;
    }
}
