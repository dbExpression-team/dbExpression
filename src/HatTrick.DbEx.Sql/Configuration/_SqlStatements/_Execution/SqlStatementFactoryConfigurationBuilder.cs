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

﻿using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementFactoryConfigurationBuilder : ISqlStatementFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public SqlStatementFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(ISqlStatementExecutorFactory factory)
        {
            configuration.StatementExecutorFactory = factory;
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlStatementExecutorFactory>()
            where TSqlStatementExecutorFactory : class, ISqlStatementExecutorFactory, new()
            => Use<TSqlStatementExecutorFactory>(null);

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlStatementExecutorFactory>(Action<TSqlStatementExecutorFactory> configureFactory)
            where TSqlStatementExecutorFactory : class, ISqlStatementExecutorFactory, new()
        {
            if (!(configuration.StatementExecutorFactory is TSqlStatementExecutorFactory))
                configuration.StatementExecutorFactory = new TSqlStatementExecutorFactory();
            configureFactory?.Invoke(configuration.StatementExecutorFactory as TSqlStatementExecutorFactory);
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use(Func<QueryExpression, ISqlStatementExecutor> factory)
        {
            configuration.StatementExecutorFactory = new DelegateSqlStatementExecutorFactory(factory ?? throw new ArgumentNullException(nameof(factory)));
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory()
        {
            configuration.StatementExecutorFactory = new SqlStatementExecutorFactory();
            return caller;
        }
        #endregion
    }
}
