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

﻿using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IRuntimeSqlDatabaseConfigurationBuilder : IRuntimeSqlDatabaseConfigurationProvider
    {
        /// <summary>
        /// Configure the factory used for providing a connection string to create connections to the database.
        /// </summary>
        IConnectionStringFactoryConfigurationBuilder ConnectionString { get; }

        /// <summary>
        /// Configure the factories used for assembly and execution of sql statements.
        /// </summary>
        ISqlStatementsConfigurationBuilderGrouping SqlStatements { get; }

        /// <summary>
        /// Configure the provider used for database schema metadata.  The provider is responsible for providing the properties of the database schema, column and table names, 
        /// column data types.
        /// generated model.
        /// </summary>
        ISqlDatabaseMetadataProviderConfigurationBuilder SchemaMetadata { get; }

        /// <summary>
        /// Configure the factory used for creation of <see cref="QueryExpression" />(s).  
        /// </summary>
        /// <remarks>All sql statements executed against a database start with an instance of a <see cref="QueryExpression" />.</remarks>
        IQueryExpressionFactoryConfigurationBuilder QueryExpressions { get; }

        /// <summary>
        /// Configure custom delegates to execute during the assembly of query expressions and execution of sql statements.  
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder Events { get; }

        /// <summary>
        /// Configure the factory used to create a value converter used to convert data to and from the target database.  
        /// </summary>
        IValueConverterFactoryConfigurationBuilder Conversions { get; }

        /// <summary>
        /// Configure the factory used for the creation of entities prior to mapping from data returned from the database.  
        /// </summary>
        IEntitiesConfigurationBuilderGrouping Entities { get; }
    }
}
