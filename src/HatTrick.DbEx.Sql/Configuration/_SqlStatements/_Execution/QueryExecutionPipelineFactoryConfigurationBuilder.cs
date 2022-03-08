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

﻿using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class QueryExecutionPipelineFactoryConfigurationBuilder : IQueryExecutionPipelineFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public QueryExecutionPipelineFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(IQueryExecutionPipelineFactory factory)
        {
            configuration.ExecutionPipelineFactory = factory;
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TQueryExecutionPipelineFactory>()
            where TQueryExecutionPipelineFactory : class, IQueryExecutionPipelineFactory, new()
            => Use<TQueryExecutionPipelineFactory>(_ => { });

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TQueryExecutionPipelineFactory>(Action<TQueryExecutionPipelineFactory> configureFactory)
            where TQueryExecutionPipelineFactory : class, IQueryExecutionPipelineFactory, new()
        {
            if (configuration.ExecutionPipelineFactory is not TQueryExecutionPipelineFactory)
                configuration.ExecutionPipelineFactory = new TQueryExecutionPipelineFactory();
            configureFactory?.Invoke(configuration.ExecutionPipelineFactory as TQueryExecutionPipelineFactory ?? throw new DbExpressionException($"Expected execution pipeline factory to return type {typeof(TQueryExecutionPipelineFactory)}."));
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory()
        {
            if (configuration.ExecutionPipelineFactory is not QueryExecutionPipelineFactory)
                configuration.ExecutionPipelineFactory = new QueryExecutionPipelineFactory();
            configuration.ExecutionPipelineFactory = new QueryExecutionPipelineFactory();
            return caller;
        }
        #endregion
    }
}
