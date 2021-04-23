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

﻿using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder :
        ISqlStatementBuilder
    {
        #region internals
        private readonly QueryExpression query;
        private readonly ISqlDatabaseMetadataProvider databaseMetadata;
        private readonly ISqlStatementAssembler assembler;
        private readonly SqlStatementAssemblerConfiguration assemblerConfiguration;
        private readonly IExpressionElementAppenderFactory elementAppenderFactory;
        private int _currentAliasCounter;
        private SqlStatement _sqlStatement;
        #endregion

        public IAppender Appender { get; }
        public ISqlParameterBuilder Parameters { get; }

        public SqlStatementBuilder(
            QueryExpression query,
            ISqlDatabaseMetadataProvider databaseMetadata,
            ISqlStatementAssembler assembler,
            SqlStatementAssemblerConfiguration assemblerConfiguration,
            IExpressionElementAppenderFactory elementAppenderFactory,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        )
        {
            this.query = query ?? throw new ArgumentNullException(nameof(query));
            this.databaseMetadata = databaseMetadata ?? throw new ArgumentNullException(nameof(databaseMetadata));
            this.assembler = assembler ?? throw new ArgumentNullException(nameof(assembler));
            this.assemblerConfiguration = assemblerConfiguration ?? throw new ArgumentNullException(nameof(assemblerConfiguration));
            this.elementAppenderFactory = elementAppenderFactory ?? throw new ArgumentNullException(nameof(elementAppenderFactory));
            Appender = appender ?? throw new ArgumentNullException(nameof(appender));
            Parameters = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
        }

        public SqlStatement CreateSqlStatement()
        {
            if (_sqlStatement is object)
                return _sqlStatement;

            var context = new AssemblyContext(assemblerConfiguration);

            assembler.AssembleStatement(query, this, context);

            return _sqlStatement = new SqlStatement(Appender, Parameters.Parameters, DbCommandType.SqlText);
        }

        public void AppendElement<T>(T element, AssemblyContext context)
            where T : class, IExpressionElement
        {           
            var appender = elementAppenderFactory.CreateElementAppender(element);
            if (appender is object)
            { 
                appender.AppendElement(element, this, context);
                return;
            }

            if (element is QueryExpression query)
            {
                AssembleStatement(query, context);
                return;
            }

            throw new DbExpressionConfigurationException($"Could not resolve an appender for element type '{element.GetType()}', please ensure an appender has been registered during startup initialization of DbExpression.");
        }

        public void AssembleStatement(QueryExpression expression, AssemblyContext context)
            => assembler.AssembleStatement(expression, this, context);

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";

        public ISqlSchemaMetadata FindMetadata(SchemaExpression schema) => databaseMetadata.FindSchemaMetadata((schema as ISqlMetadataIdentifierProvider).Identifier);
        public ISqlEntityMetadata FindMetadata(EntityExpression entity) => databaseMetadata.FindEntityMetadata((entity as ISqlMetadataIdentifierProvider).Identifier);
        public ISqlFieldMetadata FindMetadata(FieldExpression field) => databaseMetadata.FindFieldMetadata((field as ISqlMetadataIdentifierProvider).Identifier);
    }
}