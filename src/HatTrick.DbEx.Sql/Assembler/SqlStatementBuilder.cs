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

using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder<TDatabase> : ISqlStatementBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly TDatabase database;
        private readonly ISqlStatementAssemblerFactory<TDatabase> assemblerFactory;
        private readonly AssemblyContext assemblyContext;
        private readonly IExpressionElementAppenderFactory<TDatabase> elementAppenderFactory;
        private readonly IValueConverterFactory<TDatabase> valueConverterFactory;
        private int _currentAliasCounter;
        private SqlStatement? _sqlStatement;
        #endregion

        public IAppender Appender { get; private set; }
        public ISqlParameterBuilder Parameters { get; private set; }

        public SqlStatementBuilder(
            TDatabase database,
            ISqlStatementAssemblerFactory<TDatabase> assemblerFactory,
            AssemblyContext assemblyContext,
            IExpressionElementAppenderFactory<TDatabase> elementAppenderFactory,
            IAppender appender,
            ISqlParameterBuilder<TDatabase> parameterBuilder,
            IValueConverterFactory<TDatabase> valueConverterFactory
        )
        {
            this.database = database ?? throw new ArgumentNullException(nameof(database));
            this.assemblerFactory = assemblerFactory ?? throw new ArgumentNullException(nameof(assemblerFactory));
            this.assemblyContext = assemblyContext ?? throw new ArgumentNullException(nameof(assemblyContext));
            this.elementAppenderFactory = elementAppenderFactory ?? throw new ArgumentNullException(nameof(elementAppenderFactory));
            Appender = appender ?? throw new ArgumentNullException(nameof(appender));
            Parameters = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }

        public SqlStatement CreateSqlStatement<TQuery>(TQuery expression)
            where TQuery : QueryExpression
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (_sqlStatement is not null)
                return _sqlStatement;

            var assembler = assemblerFactory.CreateSqlStatementAssembler(expression.GetType())
                ?? throw new DbExpressionConfigurationException($"Could not resolve an assembler for query type '{expression.GetType()}', please ensure an assembler has been registered during startup initialization of DbExpression.");

            assembler.AssembleStatement(expression, this, assemblyContext);
            Appender.Write(assemblyContext.StatementTerminator);

            return _sqlStatement = new SqlStatement(Appender, Parameters.Parameters);
        }

        public void AppendElement<T>(T element, AssemblyContext context)
            where T : class, IExpressionElement
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (element is QueryExpression query)
            {
                AssembleStatement(query, context);
                return;
            }

            var appender = elementAppenderFactory.CreateElementAppender(element.GetType());
            appender.AppendElement(element, this, context);
        }

        public void AssembleStatement(QueryExpression expression, AssemblyContext context)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            var assembler = assemblerFactory.CreateSqlStatementAssembler(expression.GetType())
                ?? throw new DbExpressionConfigurationException($"Could not resolve an assembler for query type '{expression.GetType()}', please ensure an assembler has been registered during startup initialization of DbExpression.");
            assembler.AssembleStatement(expression, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";

        public ISqlSchemaMetadata? FindMetadata(Schema schema) => database.MetadataProvider.FindSchemaMetadata(schema.Identifier);
        public ISqlEntityMetadata? FindMetadata(Table entity) => database.MetadataProvider.FindEntityMetadata(entity.Identifier);
        public ISqlFieldMetadata? FindMetadata(Field field) => database.MetadataProvider.FindFieldMetadata(field.Identifier);
        public ISqlParameterMetadata? FindMetadata(QueryParameter parameter) => database.MetadataProvider.FindParameterMetadata(parameter.Identifier);

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