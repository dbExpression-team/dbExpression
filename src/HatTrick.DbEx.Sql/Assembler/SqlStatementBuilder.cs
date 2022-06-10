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
using HatTrick.DbEx.Sql.Converter;
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
        private readonly ISqlStatementAssemblerFactory assemblerFactory;
        private readonly SqlStatementAssemblerConfiguration assemblerConfiguration;
        private readonly IExpressionElementAppenderFactory elementAppenderFactory;
        private readonly IAppenderFactory appenderFactory;
        private readonly ISqlParameterBuilderFactory parameterBuilderFactory;
        private readonly IValueConverterFactory valueConverterFactory;
        private int _currentAliasCounter;
        private SqlStatement? _sqlStatement;
        private IAppender? _appender;
        private ISqlParameterBuilder? _parameters;
        #endregion

        public IAppender Appender => _appender ??= appenderFactory.CreateAppender() ?? throw new DbExpressionConfigurationException($"Could not resolve an appender, please ensure a an appender has been registered during startup initialization of dbExpression.");
        public ISqlParameterBuilder Parameters => _parameters ??= parameterBuilderFactory.CreateSqlParameterBuilder() ?? throw new DbExpressionConfigurationException($"Could not resolve a parameter builder, please ensure a parameter builder has been registered during startup initialization of dbExpression.");

        public SqlStatementBuilder(
            QueryExpression query,
            ISqlDatabaseMetadataProvider databaseMetadata,
            ISqlStatementAssemblerFactory assemblerFactory,
            SqlStatementAssemblerConfiguration assemblerConfiguration,
            IExpressionElementAppenderFactory elementAppenderFactory,
            IAppenderFactory appenderFactory,
            ISqlParameterBuilderFactory parameterBuilderFactory,
            IValueConverterFactory valueConverterFactory
        )
        {
            this.query = query ?? throw new ArgumentNullException(nameof(query));
            this.databaseMetadata = databaseMetadata ?? throw new ArgumentNullException(nameof(databaseMetadata));
            this.assemblerFactory = assemblerFactory ?? throw new ArgumentNullException(nameof(assemblerFactory));
            this.assemblerConfiguration = assemblerConfiguration ?? throw new ArgumentNullException(nameof(assemblerConfiguration));
            this.elementAppenderFactory = elementAppenderFactory ?? throw new ArgumentNullException(nameof(elementAppenderFactory));
            this.appenderFactory = appenderFactory ?? throw new ArgumentNullException(nameof(appenderFactory));
            this.parameterBuilderFactory = parameterBuilderFactory ?? throw new ArgumentNullException(nameof(parameterBuilderFactory));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }

        public SqlStatement CreateSqlStatement()
        {
            if (_sqlStatement is not null)
                return _sqlStatement;

            var context = assemblerConfiguration.ToAssemblyContext();

            var assembler = assemblerFactory.CreateSqlStatementAssembler(query)
                ?? throw new DbExpressionConfigurationException($"Could not resolve an assembler for query type '{query.GetType()}', please ensure an assembler has been registered during startup initialization of DbExpression.");

            assembler.AssembleStatement(query, this, context);
            Appender.Write(context.StatementTerminator);

            return _sqlStatement = new SqlStatement(Appender, Parameters.Parameters);
        }

        public void AppendElement<T>(T element, AssemblyContext context)
            where T : class, IExpressionElement
        {
            var appender = elementAppenderFactory.CreateElementAppender(element);
            if (appender is not null)
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
        {
            var assembler = assemblerFactory.CreateSqlStatementAssembler(expression)
                ?? throw new DbExpressionConfigurationException($"Could not resolve an assembler for query type '{query.GetType()}', please ensure an assembler has been registered during startup initialization of DbExpression.");
            assembler.AssembleStatement(expression, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";

        public ISqlSchemaMetadata? FindMetadata(Schema schema) => databaseMetadata.FindSchemaMetadata(schema.Identifier);
        public ISqlEntityMetadata? FindMetadata(Table entity) => databaseMetadata.FindEntityMetadata(entity.Identifier);
        public ISqlFieldMetadata? FindMetadata(Field field) => databaseMetadata.FindFieldMetadata(field.Identifier);
        public ISqlParameterMetadata? FindMetadata(QueryParameter parameter) => databaseMetadata.FindParameterMetadata(parameter.Identifier);

        public (Type, object?) ConvertValue(object? value, Field? field)
        {
            if (value is NullElement)
                value = null;

            var type = field is null ? value?.GetType() : field.DeclaredType;
            if (type is null)
                type = typeof(object);

            var converter = valueConverterFactory.CreateConverter(type)
                ?? throw new DbExpressionConfigurationException($"Could not resolve a value converter for '{type}', please ensure an value converter has been registered during startup initialization of DbExpression.");

            return converter.ConvertToDatabase(value);
        }
    }
}