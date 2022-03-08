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
    public class SqlConnectionFactoryConfigurationBuilder : ISqlConnectionFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public SqlConnectionFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(ISqlConnectionFactory factory)
        {
            configuration.ConnectionFactory = factory;
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlConnectionFactory>()
            where TSqlConnectionFactory : class, ISqlConnectionFactory, new()
            => Use<TSqlConnectionFactory>(_ => { });

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlConnectionFactory>(Action<TSqlConnectionFactory> configureFactory)
            where TSqlConnectionFactory : class, ISqlConnectionFactory, new()
        {
            if (configuration.ConnectionFactory is not TSqlConnectionFactory)
                configuration.ConnectionFactory = new TSqlConnectionFactory();
            configureFactory?.Invoke((configuration.ConnectionFactory as TSqlConnectionFactory)!);
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use(Func<string, IDbConnection> factory)
        {
            configuration.ConnectionFactory = new DelegateSqlConnectionFactory(factory ?? throw new ArgumentNullException(nameof(factory)));
            return caller;
        }
        #endregion
    }
}
