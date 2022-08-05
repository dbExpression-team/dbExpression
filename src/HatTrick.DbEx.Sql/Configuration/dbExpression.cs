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
using System.Collections.Generic;
using TinyIoC;

namespace HatTrick.DbEx.Sql.Configuration
{
#pragma warning disable IDE1006 // Naming Styles
    public class dbExpression
#pragma warning restore IDE1006 // Naming Styles
    {
        #region internals
        private static TinyIoCServiceCollection? _services;
        private static readonly object _lock = new object();
        #endregion

        #region constructors
        private dbExpression()
        { 
        
        }
        #endregion

        #region methods
        /// <summary>
        /// Creates the default services collection where runtime services can be registered to support dependency injection.
        /// </summary>
        /// <returns>A <see cref="IServiceCollection"/> for registering runtime services.</returns>
        public static IServiceCollection CreateServiceCollection()
        {
            lock (_lock)
            {
                TinyIoCContainer.Current.Clear();
                _services = new(TinyIoCContainer.Current);
            }
            return _services;
        }

        /// <summary>
        /// A shorthand method to configure and use dbExpression.  Use this when there is no need to configure or customize any services external to <paramref name="databases"/>.
        /// </summary>
        /// <param name="databases">Configure one or more databases for runtime use with dbExpression.</param>
        /// <remarks>
        /// Internally, this creates a default services collection, registers database services for each database configured via <paramref name="databases"/>,
        /// and builds the default service provider used with the dbExpression runtime.
        /// </remarks>
        public static void Configure(params Action<ISqlDatabaseRuntimeServicesBuilder>[] databases)
        {
            CreateServiceCollection().AddDbExpression(databases);
            BuildServiceProvider();
        }

        /// <summary>
        /// Builds the default services collection into an <see cref="IServiceProvider"/> used to resolve runtime dependencies.
        /// </summary>
        /// <returns>A <see cref="IServiceProvider"/> which can be utilized to resolve runtime services that were registered with the default <see cref="IServiceCollection"/>.</returns>
        /// <exception cref="DbExpressionConfigurationException"></exception>
        public static IServiceProvider BuildServiceProvider()
        {
            if (_services is null)
                throw new DbExpressionConfigurationException($"The service collection has not been created, ensure the service collection has been created " +
                    $"via '{nameof(CreateServiceCollection)}' and services for one or more databases have been registered " +
                    $"via '{nameof(ServiceCollectionExtensions.AddDbExpression)}'."
                );

            IServiceProvider? provider = null;
            lock (_lock)
            {
                provider = _services.BuildServiceProvider();
                provider.InitializeStaticRuntimes();
            }
            return provider;
        }
        #endregion
    }
}
