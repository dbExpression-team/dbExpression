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
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
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
        private Dictionary<string, int> syntheticAliases = new (StringComparer.OrdinalIgnoreCase);
        private int currentAliasIndex;
        private static SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
        private static string[] aliases = new[] { "t0", "t1", "t2", "t3", "t4", "t5", "t6", "t7", "t8", "t9", "t10", "t11", "t12", "t13", "t14", "t15", "t16", "t17", "t18", "t19" };
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

        public string GenerateAlias() 
            => $"__{currentAliasIndex++}";

        public string GetPlatformName(ISqlMetadataIdentifierProvider expression) 
            => (metadataProvider.GetMetadata<ISqlMetadata>(expression.Identifier)?.Name
                ?? DbExpressionMetadataException.ThrowMetadataResolutionWithReturn<string>("expression", expression.Identifier.ToString()));
        
        public ISqlColumnMetadata GetPlatformMetadata(Field field) 
            => metadataProvider.GetMetadata<ISqlColumnMetadata>(field.Identifier) 
                ?? DbExpressionMetadataException.ThrowMetadataResolutionWithReturn<ISqlColumnMetadata>("column", field.Name);
        
        public ISqlParameterMetadata GetPlatformMetadata(QueryParameter parameter) 
            => metadataProvider.GetMetadata<ISqlParameterMetadata>(parameter.Identifier)
                ?? DbExpressionMetadataException.ThrowMetadataResolutionWithReturn<ISqlParameterMetadata>("parameter", parameter.Name);

        public (Type, object?) ConvertValue(object? value, Field? field)
        {
            if (value is NullElement)
                value = null;

            var type = field is null ? value?.GetType() : field.DeclaredType;
            if (type is null)
                type = typeof(object);

            var converter = valueConverterFactory.CreateConverter(type) ?? DbExpressionConfigurationException.ThrowServiceResolutionWithReturn<IValueConverter>();

            return converter.ConvertToDatabase(value);
        }

        public string? ResolveTableAlias(IExpressionElement expression)
        {
            if (expression is IExpressionAliasProvider aliasProvider && !string.IsNullOrWhiteSpace(aliasProvider.Alias))
                return ResolveTableAlias(aliasProvider.Alias!);

            if (expression is IExpressionNameProvider nameProvider)
                return ResolveTableAlias(nameProvider.Name);

            return null;
        }

        public string? ResolveTableAlias(string tableName)
        {
            if (!assemblyContext.UseSyntheticAliases)
                return tableName;

            if (syntheticAliases.TryGetValue(tableName, out int index))
                return aliases[index];

            if (currentAliasIndex >= aliases.Length)
                GrowAliases();

            syntheticAliases.Add(tableName, currentAliasIndex);
            return aliases[currentAliasIndex++];
        }

        private void GrowAliases()
        {
            semaphore.Wait();
            try
            {
                if (currentAliasIndex >= aliases.Length)
                {
                    var @new = new List<string>(aliases);
                    for (var i = currentAliasIndex; i < aliases.Length * 2; i++)
                        @new.Add($"t{i}");
                    aliases = @new.ToArray();
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
        #endregion
    }
}