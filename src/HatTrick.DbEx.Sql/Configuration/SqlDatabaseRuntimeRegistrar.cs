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

namespace HatTrick.DbEx.Sql.Configuration
{
    /// <summary>
    /// Keeps a list of all database types that are configured for use with dbExpression.
    /// </summary>
    public class SqlDatabaseRuntimeRegistrar : 
        ISqlDatabaseRuntimeServicesBuilder,
        ISqlDatabaseRuntimeServicesRegistrar
    {
        #region internals
        private readonly IServiceCollection _services;
        private readonly HashSet<Type> databases = new();
        #endregion

        #region interface
        public IServiceCollection Services => _services;
        #endregion

        #region constructors
        public SqlDatabaseRuntimeRegistrar(IServiceCollection services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <summary>
        /// Register a database type 
        /// </summary>
        /// <typeparam name="TDatabase"></typeparam>
        /// <returns></returns>
        public SqlDatabaseRuntimeRegistrar Register<TDatabase>()
            where TDatabase : class, ISqlDatabaseRuntime
        {
            if (databases.Contains(typeof(TDatabase)))
                throw new DbExpressionConfigurationException(ExceptionMessages.DuplicateRegistration<TDatabase>());
            databases.Add(typeof(TDatabase));
            return this;
        }

        /// <summary>
        /// Add all the database types registered via <see cref="Register{TDatabase}"/> with the service collection.
        /// </summary>
        public void RegisterAllDatabaseTypes()
        {
            Services.AddSingleton(new RegisteredSqlDatabaseRuntimeTypes(databases));
        }
        #endregion
    }
}
