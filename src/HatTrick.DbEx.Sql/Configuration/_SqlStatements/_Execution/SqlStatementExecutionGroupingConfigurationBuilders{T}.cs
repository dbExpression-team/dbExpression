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

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementExecutionGroupingConfigurationBuilders<TDatabase> : ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ISqlStatementsConfigurationBuilderGrouping<TDatabase> caller;
        private readonly IServiceCollection services;
        private ISqlStatementExecutorFactoryConfigurationBuilder<TDatabase>? _executors;
        private IQueryExecutionPipelineFactoryConfigurationBuilder<TDatabase>? _pipelines;
        private IDbConnectionFactoryConfigurationBuilder<TDatabase>? _connections;
        #endregion

        #region interface
        /// <inheritdoc />
        public ISqlStatementExecutorFactoryConfigurationBuilder<TDatabase> Executor => _executors ??= new SqlStatementExecutionFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public IQueryExecutionPipelineFactoryConfigurationBuilder<TDatabase> Pipeline => _pipelines ??= new QueryExecutionPipelineFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public IDbConnectionFactoryConfigurationBuilder<TDatabase> Connection => _connections ??= new SqlConnectionFactoryConfigurationBuilder<TDatabase>(this, services);
        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Assembly => caller.Assembly;
        #endregion

        #region constructors
        public SqlStatementExecutionGroupingConfigurationBuilders(ISqlStatementsConfigurationBuilderGrouping<TDatabase> caller, IServiceCollection services)
        {
            this.caller = caller ?? throw new ArgumentNullException(nameof(caller));
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion
    }
}
