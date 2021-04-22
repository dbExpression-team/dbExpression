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

﻿using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementExecutionGroupingConfigurationBuilders : ISqlStatementExecutionGroupingConfigurationBuilders
    {
        #region internals
        private ISqlStatementsConfigurationBuilderGrouping caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private ISqlStatementFactoryConfigurationBuilder _executors;
        private IExecutionPipelineFactoryConfigurationBuilder _pipelines;
        private ISqlConnectionFactoryConfigurationBuilder _connections;
        #endregion

        #region interface
        public ISqlStatementFactoryConfigurationBuilder Executor => _executors ?? (_executors = new SqlStatementFactoryConfigurationBuilder(this, configuration));
        public IExecutionPipelineFactoryConfigurationBuilder Pipeline => _pipelines ?? (_pipelines = new ExecutionPipelineFactoryConfigurationBuilder(this, configuration));
        public ISqlConnectionFactoryConfigurationBuilder Connection => _connections ?? (_connections = new SqlConnectionFactoryConfigurationBuilder(this, configuration));
        public ISqlStatementAssemblyGroupingConfigurationBuilders Assembly => caller.Assembly;
        #endregion

        #region constructors
        public SqlStatementExecutionGroupingConfigurationBuilders(ISqlStatementsConfigurationBuilderGrouping caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion
    }
}
