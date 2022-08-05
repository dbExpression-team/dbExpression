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
    public abstract class SqlDatabaseRuntimeConfigurationBuilder<TDatabase> :
        ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private IConnectionStringFactoryConfigurationBuilder<TDatabase>? _connectionString;
        private ISqlStatementsConfigurationBuilderGrouping<TDatabase>? _assembler;
        private IQueryExpressionFactoryConfigurationBuilder<TDatabase>? _queryExpressions;
        private IValueConverterFactoryConfigurationBuilder<TDatabase>? _valueConverter;
        private IQueryExecutionPipelineEventConfigurationBuilder<TDatabase>? _event;
        private IEntitiesConfigurationBuilderGrouping<TDatabase>? _entities;
        #endregion

        #region interface
        public IServiceCollection Services { get; private set; }
        IConnectionStringFactoryConfigurationBuilder<TDatabase> ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>.ConnectionString => _connectionString ??= new ConnectionStringFactoryConfigurationBuilder<TDatabase>(Services);
        IQueryExpressionFactoryConfigurationBuilder<TDatabase> ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>.QueryExpressions => _queryExpressions ??= new QueryExpressionFactoryConfigurationBuilder<TDatabase>(Services);
        IEntitiesConfigurationBuilderGrouping<TDatabase> ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>.Entities => _entities ??= new EntitiesConfigurationBuilderGrouping<TDatabase>(Services);
        IValueConverterFactoryConfigurationBuilder<TDatabase> ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>.Conversions => _valueConverter ??= new ValueConverterFactoryConfigurationBuilder<TDatabase>(Services);
        ISqlStatementsConfigurationBuilderGrouping<TDatabase> ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>.SqlStatements => _assembler ??= new SqlStatementsConfigurationBuilderGrouping<TDatabase>(Services);
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>.Events => _event ??= new QueryExecutionPipelineEventConfigurationBuilder<TDatabase>(Services);
        #endregion

        #region constructors
        protected SqlDatabaseRuntimeConfigurationBuilder(IServiceCollection services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services));
        }
        #endregion

        public void Build()
        { 
            ((this as ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>).Events as QueryExecutionPipelineEventConfigurationBuilder<TDatabase>)!.Build();
        }
    }
}
