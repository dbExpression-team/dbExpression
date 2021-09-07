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
    public class RuntimeSqlDatabaseConfigurationBuilder :
        IRuntimeSqlDatabaseConfigurationBuilder,
        IRuntimeSqlDatabaseConfigurationProvider
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IConnectionStringFactoryConfigurationBuilder _connectionString;
        private ISqlStatementsConfigurationBuilderGrouping _assembler;
        private ISqlDatabaseMetadataProviderConfigurationBuilder _metadata;
        private IQueryExpressionFactoryConfigurationBuilder _queryExpressions;
        private IValueConverterFactoryConfigurationBuilder _valueConverter;
        private IExecutionPipelineEventConfigurationBuilder _event;

        private IEntitiesConfigurationBuilderGrouping _entities;
        #endregion

        #region interface
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabaseConfigurationProvider.Configuration => configuration;
        public IConnectionStringFactoryConfigurationBuilder ConnectionString => _connectionString ?? (_connectionString = new ConnectionStringFactoryConfigurationBuilder(configuration));
        public ISqlDatabaseMetadataProviderConfigurationBuilder SchemaMetadata => _metadata ?? (_metadata = new SqlDatabaseMetadataProviderConfigurationBuilder(configuration));
        public IQueryExpressionFactoryConfigurationBuilder QueryExpressions => _queryExpressions ?? (_queryExpressions = new QueryExpressionFactoryConfigurationBuilder(configuration));
        public IEntitiesConfigurationBuilderGrouping Entities => _entities ?? (_entities = new EntitiesConfigurationBuilderGrouping(configuration));
        public IValueConverterFactoryConfigurationBuilder Conversions => _valueConverter ?? (_valueConverter = new ValueConverterFactoryConfigurationBuilder(configuration));
        public ISqlStatementsConfigurationBuilderGrouping SqlStatements => _assembler ?? (_assembler = new SqlStatementsConfigurationBuilderGrouping(configuration));     
        public IExecutionPipelineEventConfigurationBuilder Events => _event ?? (_event = new ExecutionPipelineEventConfigurationBuilder(configuration));
        #endregion

        #region constructors
        public RuntimeSqlDatabaseConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected RuntimeSqlDatabaseConfigurationBuilder()
        {

        }
        #endregion
    }
}
