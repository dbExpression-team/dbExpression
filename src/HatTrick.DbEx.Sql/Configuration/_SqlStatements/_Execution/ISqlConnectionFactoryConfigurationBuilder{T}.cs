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

﻿using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlConnectionFactoryConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Use a custom factory for creating creating an <see cref="ISqlConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(ISqlConnectionFactory factory);

        /// <summary>
        /// Use a custom factory for creating creating an <see cref="ISqlConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlConnectionFactory> factory);

        /// <summary>
        /// Use a custom factory for creating creating an <see cref="ISqlConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use<TSqlConnectionFactory>()
            where TSqlConnectionFactory : class, ISqlConnectionFactory;

        /// <summary>
        /// Use a connection string for creating an <see cref="ISqlConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<ISqlConnection> factory);

        /// <summary>
        /// Use the service provider and a connection string for creating an <see cref="ISqlConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> Use(Func<IServiceProvider, ISqlConnection> factory);
    }
}
