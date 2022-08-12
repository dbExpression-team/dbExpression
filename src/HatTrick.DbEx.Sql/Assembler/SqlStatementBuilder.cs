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
using Microsoft.Extensions.Logging;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder<TDatabase> : ISqlStatementBuilder<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly ILogger<SqlStatementBuilder<TDatabase>> logger;
        private readonly TDatabase database;
        private readonly AssemblyContext assemblyContext;
        private readonly IExpressionElementAppenderFactory<TDatabase> elementAppenderFactory;
        private readonly IValueConverterFactory<TDatabase> valueConverterFactory;
        private int _currentAliasCounter;
        #endregion

        public IAppender Appender { get; private set; }
        public ISqlParameterBuilder Parameters { get; private set; }

        public SqlStatementBuilder(
            ILogger<SqlStatementBuilder<TDatabase>> logger,
            TDatabase database,
            AssemblyContext assemblyContext,
            IExpressionElementAppenderFactory<TDatabase> elementAppenderFactory,
            IAppender appender,
            ISqlParameterBuilder<TDatabase> parameterBuilder,
            IValueConverterFactory<TDatabase> valueConverterFactory
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.database = database ?? throw new ArgumentNullException(nameof(database));
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

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for {query}.", expression.GetType());
            
            AppendElement(expression, assemblyContext);

            Appender.Write(assemblyContext.StatementTerminator);

            return new SqlStatement(Appender, Parameters.Parameters);
        }

        public void AppendElement<T>(T element, AssemblyContext context)
            where T : class, IExpressionElement
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            if (context is null)
                throw new ArgumentNullException(nameof(context));

            var appender = elementAppenderFactory.CreateElementAppender(element.GetType());

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Appending element {element}.", element.GetType());

            appender.AppendElement(element, this, context);
        }

        public string GenerateAlias() => $"_t{++_currentAliasCounter}";

        public ISqlMetadata? FindMetadata(Schema schema) => database.MetadataProvider.GetMetadata<ISqlMetadata>(schema.Identifier);
        public ISqlMetadata? FindMetadata(Table entity) => database.MetadataProvider.GetMetadata<ISqlMetadata>(entity.Identifier);
        public ISqlColumnMetadata? FindMetadata(Field field) => database.MetadataProvider.GetMetadata<ISqlColumnMetadata>(field.Identifier);
        public ISqlParameterMetadata? FindMetadata(QueryParameter parameter) => database.MetadataProvider.GetMetadata<ISqlParameterMetadata>(parameter.Identifier);

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