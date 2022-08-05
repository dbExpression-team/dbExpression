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
    public class SqlStatementsConfigurationBuilderGrouping<TDatabase> : ISqlStatementsConfigurationBuilderGrouping<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly IServiceCollection services;
        private ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase>? _assembly;
        private ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase>? _execution;
        #endregion

        #region interface
        /// <inheritdoc />
        public ISqlStatementAssemblyGroupingConfigurationBuilders<TDatabase> Assembly => _assembly ??= new SqlStatementAssemblyGroupingConfigurationBuilders<TDatabase>(this, services);
        /// <inheritdoc />
        public ISqlStatementExecutionGroupingConfigurationBuilders<TDatabase> QueryExecution => _execution ??= new SqlStatementExecutionGroupingConfigurationBuilders<TDatabase>(this, services);
        #endregion

        #region constructors
        public SqlStatementsConfigurationBuilderGrouping(IServiceCollection services)
        {
            this.services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion
    }
}
