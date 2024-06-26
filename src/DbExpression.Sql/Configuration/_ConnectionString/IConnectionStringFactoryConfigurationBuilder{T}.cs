#region license
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

﻿using DbExpression.Sql.Connection;
using System;

namespace DbExpression.Sql.Configuration
{
    public interface IConnectionStringFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use the provided connection string to connect to the database.
        /// </summary>
        void Use(string connectionString);

        /// <summary>
        /// Use the delegate to provide a connection string to connect to the database.
        /// </summary>
        void Use(Func<string> factory);

        /// <summary>
        /// Use the delegate to provide a connection string to connect to the database.
        /// </summary>
        void Use(Func<IServiceProvider, string> factory);

        /// <summary>
        /// Use a custom connection string factory to provide a connection string to connect to the database.
        /// </summary>
        void Use(IConnectionStringFactory factory);

        /// <summary>
        /// Use a custom connection string factory to provide a connection string to connect to the database.
        /// </summary>
        void Use<TConnectionStringFactory>()
            where TConnectionStringFactory : class, IConnectionStringFactory;

        /// <summary>
        /// Use a custom factory for creating a factory for creating connection strings to connect to the database.
        /// </summary>
        /// <param name="factory">A delegate responsible for creating an <see cref="IConnectionStringFactory{TDatabase}"/>.</param>
        void Use(Func<IServiceProvider, IConnectionStringFactory> factory);
    }
}
