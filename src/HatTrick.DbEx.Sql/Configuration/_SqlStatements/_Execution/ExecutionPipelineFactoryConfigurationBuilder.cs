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
    public class ExecutionPipelineFactoryConfigurationBuilder : IExecutionPipelineFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public ExecutionPipelineFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(IExecutionPipelineFactory factory)
        {
            configuration.ExecutionPipelineFactory = factory;
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>()
            where TExecutionPipelineFactory : class, IExecutionPipelineFactory, new()
            => Use<TExecutionPipelineFactory>(null);

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>(Action<TExecutionPipelineFactory> configureFactory)
            where TExecutionPipelineFactory : class, IExecutionPipelineFactory, new()
        {
            if (!(configuration.ExecutionPipelineFactory is TExecutionPipelineFactory))
                configuration.ExecutionPipelineFactory = new TExecutionPipelineFactory();
            configureFactory?.Invoke(configuration.ExecutionPipelineFactory as TExecutionPipelineFactory);
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory()
        {
            if (!(configuration.ExecutionPipelineFactory is ExecutionPipelineFactory))
                configuration.ExecutionPipelineFactory = new ExecutionPipelineFactory();
            configuration.ExecutionPipelineFactory = new ExecutionPipelineFactory();
            return caller;
        }
        #endregion
    }
}
