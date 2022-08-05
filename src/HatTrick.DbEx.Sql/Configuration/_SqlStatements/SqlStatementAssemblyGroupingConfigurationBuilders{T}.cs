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
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> : ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ISqlStatementsConfigurationBuilderGrouping<TDatabase> caller;
        private readonly IServiceCollection services;
        private IExpressionElementAppenderFactoryConfigurationBuilder<TDatabase>? _elementAppender;
        private IAppenderFactoryConfigurationBuilder<TDatabase>? _appender;
        private ISqlParameterBuilderFactoryConfigurationBuilder<TDatabase>? _parameter;
        private ISqlStatementBuilderFactoryConfigurationBuilder<TDatabase>? _statement;
        private ISqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>? _assembler;
        private readonly SqlStatementAssemblerConfiguration assemblerConfiguration = new();
        #endregion

        #region interface
        /// <inheritdoc />
        public IExpressionElementAppenderFactoryConfigurationBuilder<TDatabase> ElementAppender => _elementAppender ??= new ExpressionElementAppenderFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public IAppenderFactoryConfigurationBuilder<TDatabase> StatementAppender => _appender ??= new AppenderFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public ISqlParameterBuilderFactoryConfigurationBuilder<TDatabase> ParameterBuilder => _parameter ??= new SqlParameterBuilderFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public ISqlStatementBuilderFactoryConfigurationBuilder<TDatabase> StatementBuilder => _statement ??= new SqlStatementBuilderFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public ISqlStatementAssemblerFactoryConfigurationBuilder<TDatabase> StatementAssembler => _assembler ??= new SqlStatementAssemblerFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> QueryExecution => caller.QueryExecution;
        #endregion

        #region constructors
        public SqlStatementAssemblyGroupingConfigurationBuilders(ISqlStatementsConfigurationBuilderGrouping<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        #region methods
        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> ConfigureOutputSettings(Action<SqlStatementAssemblerConfiguration> config)
        {
            if (config is null)
                throw new ArgumentNullException(nameof(config));

            config(assemblerConfiguration);
            services.TryAddSingleton<SqlStatementAssemblerConfiguration>(assemblerConfiguration); 
            return this;
        }
        #endregion
    }
}
