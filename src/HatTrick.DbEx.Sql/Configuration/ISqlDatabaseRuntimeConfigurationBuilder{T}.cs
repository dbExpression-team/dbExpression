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

using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlDatabaseRuntimeConfigurationBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        /// <summary>
        /// Configuration for providing a connection string to create connections to the database.
        /// </summary>
        IConnectionStringFactoryConfigurationBuilder<TDatabase> ConnectionString { get; }

        /// <summary>
        /// Configuration for providing services used for assembly and execution of sql statements.
        /// </summary>
        ISqlStatementsConfigurationBuilderGrouping<TDatabase> SqlStatements { get; }

        /// <summary>
        /// Configuration for providing <see cref="QueryExpression" />(s).  
        /// </summary>
        /// <remarks>All sql statements executed against a database start with an instance of a <see cref="QueryExpression" />.</remarks>
        IQueryExpressionFactoryConfigurationBuilder<TDatabase> QueryExpressions { get; }

        /// <summary>
        /// Configure events to receive notifications during the assembly and execution of sql statements.  
        /// </summary>
        IQueryExecutionPipelineEventConfigurationBuilder<TDatabase> Events { get; }

        /// <summary>
        /// Configuration for providing value converters used to convert data to and from the target database.  
        /// </summary>
        IValueConverterFactoryConfigurationBuilder<TDatabase> Conversions { get; }

        /// <summary>
        /// Configuration for the services used for the creation of entities prior to mapping from data returned from the database.  
        /// </summary>
        IEntitiesConfigurationBuilderGrouping<TDatabase> Entities { get; }

        /// <summary>
        /// Configuration logging settings.  
        /// </summary>
        ILoggingOptionsBuilder<TDatabase> Logging { get; }
    }
}
