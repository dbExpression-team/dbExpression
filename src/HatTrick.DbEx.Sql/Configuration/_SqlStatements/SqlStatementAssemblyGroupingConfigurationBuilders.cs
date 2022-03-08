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
    public class SqlStatementAssemblyGroupingConfigurationBuilders : ISqlStatementAssemblyGroupingConfigurationBuilders
    {
        #region internals
        private readonly ISqlStatementsConfigurationBuilderGrouping caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IExpressionElementAppenderFactoryConfigurationBuilder? _elementAppender;
        private IAppenderFactoryConfigurationBuilder? _appender;
        private ISqlParameterBuilderFactoryConfigurationBuilder? _parameter;
        private ISqlStatementBuilderFactoryConfigurationBuilder? _statement;
        private ISqlStatementAssemblerFactoryConfigurationBuilder? _assembler;
        #endregion

        #region interface
        public IExpressionElementAppenderFactoryConfigurationBuilder ElementAppender => _elementAppender ??= new ExpressionElementAppenderFactoryConfigurationBuilder(this, configuration);
        public IAppenderFactoryConfigurationBuilder StatementAppender => _appender ??= new AppenderFactoryConfigurationBuilder(this, configuration);
        public ISqlParameterBuilderFactoryConfigurationBuilder ParameterBuilder => _parameter ??= new SqlParameterBuilderFactoryConfigurationBuilder(this, configuration);
        public ISqlStatementBuilderFactoryConfigurationBuilder StatementBuilder => _statement ??= new SqlStatementBuilderFactoryConfigurationBuilder(this, configuration);
        public ISqlStatementAssemblerFactoryConfigurationBuilder StatementAssembler => _assembler ??= new SqlStatementAssemblerFactoryConfigurationBuilder(this, configuration);
        public ISqlStatementExecutionGroupingConfigurationBuilders QueryExecution => caller.QueryExecution;
        #endregion

        #region constructors
        public SqlStatementAssemblyGroupingConfigurationBuilders(ISqlStatementsConfigurationBuilderGrouping caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }
        #endregion

        #region methods
        public ISqlStatementAssemblyGroupingConfigurationBuilders ConfigureOutputSettings(Action<SqlStatementAssemblerConfiguration> config)
        {
            config?.Invoke(configuration.AssemblerConfiguration);
            return this;
        }
        #endregion
    }
}
