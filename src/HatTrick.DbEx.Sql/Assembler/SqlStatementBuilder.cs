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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementBuilder : ISqlStatementBuilder
    {
        #region internals
        private readonly ILogger<SqlStatementBuilder> logger;
        private readonly ISqlDatabaseMetadataProvider metadataProvider;
        private readonly AssemblyContext assemblyContext;
        private readonly IExpressionElementAppenderFactory elementAppenderFactory;
        private readonly IValueConverterFactory valueConverterFactory;
        private Dictionary<string, string>? syntheticAliases;
        private int currentAliasCounter;
        #endregion

        #region interface
        public IAppender Appender { get; private set; }
        public ISqlParameterBuilder Parameters { get; private set; }
        #endregion

        #region constructors
        public SqlStatementBuilder(
            ILogger<SqlStatementBuilder> logger,
            ISqlDatabaseMetadataProvider metadataProvider,
            AssemblyContext assemblyContext,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder,
            IExpressionElementAppenderFactory elementAppenderFactory,
            IValueConverterFactory valueConverterFactory
        )
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.metadataProvider = metadataProvider ?? throw new ArgumentNullException(nameof(metadataProvider));
            this.assemblyContext = assemblyContext ?? throw new ArgumentNullException(nameof(assemblyContext));
            Appender = appender ?? throw new ArgumentNullException(nameof(appender));
            Parameters = parameterBuilder ?? throw new ArgumentNullException(nameof(parameterBuilder));
            this.elementAppenderFactory = elementAppenderFactory ?? throw new ArgumentNullException(nameof(elementAppenderFactory));
            this.valueConverterFactory = valueConverterFactory ?? throw new ArgumentNullException(nameof(valueConverterFactory));
        }
        #endregion

        #region methods
        public SqlStatement CreateSqlStatement<TQuery>(TQuery expression)
            where TQuery : QueryExpression
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            if (logger.IsEnabled(LogLevel.Trace))
                logger.LogTrace("Creating sql statement for {query}.", expression.GetType());

            syntheticAliases = expression is SelectQueryExpression ? new(StringComparer.OrdinalIgnoreCase) : null;

            AppendElement(expression, assemblyContext);

            Appender.Write(assemblyContext.StatementTerminator);

            return new SqlStatement(expression, Appender, Parameters.Parameters);
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

        public string GenerateAlias() => $"__{currentAliasCounter++}";

        public string GetPlatformName(ISqlMetadataIdentifierProvider expression) => (metadataProvider.GetMetadata<ISqlMetadata>(expression.Identifier) ?? throw new DbExpressionMetadataException(ExceptionMessages.MetadataResolution("parameter", expression.Identifier.ToString()))).Name;
        public ISqlColumnMetadata GetPlatformMetadata(Field field) => metadataProvider.GetMetadata<ISqlColumnMetadata>(field.Identifier) ?? throw new DbExpressionMetadataException(ExceptionMessages.MetadataResolution("column", field.Name));
        public ISqlParameterMetadata GetPlatformMetadata(QueryParameter parameter) => metadataProvider.GetMetadata<ISqlParameterMetadata>(parameter.Identifier) ?? throw new DbExpressionMetadataException(ExceptionMessages.MetadataResolution("parameter", parameter.Name));

        public (Type, object?) ConvertValue(object? value, Field? field)
        {
            if (value is NullElement)
                value = null;

            var type = field is null ? value?.GetType() : field.DeclaredType;
            if (type is null)
                type = typeof(object);

            var converter = valueConverterFactory.CreateConverter(type) ??
                throw new DbExpressionConfigurationException(ExceptionMessages.ServiceResolution(type));

            return converter.ConvertToDatabase(value);
        }

        public string? ResolveTableAlias(IExpressionElement expression)
        {
            if (expression is IExpressionAliasProvider aliasProvider && !string.IsNullOrWhiteSpace(aliasProvider.Alias))
                return ResolveTableAlias(aliasProvider.Alias!);

            if (expression is EntityExpression entity)
                return ResolveTableAlias(GetPlatformName(entity));

            if (expression is IExpressionNameProvider nameProvider)
                return ResolveTableAlias(nameProvider.Name);

            return null;
        }

        public string? ResolveTableAlias(string tableName)
        {
            if (syntheticAliases is null)
                return tableName;

            if (syntheticAliases.TryGetValue(tableName, out string? synthetic))
                return synthetic;

            //use what was provided if it's shorter than a generated alias, assume we'll never get over 99 ("_t99") on aliases
            synthetic = tableName.Length <= 4 ? tableName : $"_t{currentAliasCounter++}";
            syntheticAliases.Add(tableName, synthetic);
            return synthetic;
        }
        #endregion
    }
}