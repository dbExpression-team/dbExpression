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
using System;
using System.Collections.Concurrent;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class SqlStatementAssemblerFactoryWithDiscovery<TDatabase> : ISqlStatementAssemblerFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<Type, ISqlStatementAssembler<TDatabase>?> overrides;
        private readonly ConcurrentDictionary<Type, Func<Type, ISqlStatementAssembler<TDatabase>?>> assemblers = new();
        #endregion

        #region constructors
        public SqlStatementAssemblerFactoryWithDiscovery(Func<Type, ISqlStatementAssembler<TDatabase>?> overrides)
        {
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
        }
        #endregion

        #region methods
        public ISqlStatementAssembler<TDatabase, T> CreateSqlStatementAssembler<T>()
            where T : QueryExpression
            => (CreateSqlStatementAssembler(typeof(T)) as ISqlStatementAssembler<TDatabase, T>)!;

        public ISqlStatementAssembler<TDatabase> CreateSqlStatementAssembler(Type queryType)
        {
            if (TryResolveSqlStatementAssemblerFactory(queryType, out ISqlStatementAssembler<TDatabase>? assembler))
                return assembler!;

            throw new DbExpressionConfigurationException($"Could not resolve a sql statement assembler for type '{queryType}'.");
        }
        
        protected virtual bool TryResolveSqlStatementAssemblerFactory(Type type, out ISqlStatementAssembler<TDatabase>? appender)
        {
            appender = default;
            try
            {
                var factory = ResolveSqlStatementAssemblerFactory(type, type);
                if (factory is not null)
                    appender = factory(type);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private Func<Type, ISqlStatementAssembler<TDatabase>?>? ResolveSqlStatementAssemblerFactory(Type currentType, Type requestedType)
        {
            if (currentType is null)
                return null;

            if (assemblers.TryGetValue(currentType, out Func<Type, ISqlStatementAssembler<TDatabase>?>? factory))
            {
                if (currentType != requestedType)
                    assemblers.TryAdd(requestedType, factory);
                return factory;
            }

            var assemblerType = typeof(ISqlStatementAssembler<>).MakeGenericType(new[] { currentType });
            var @override = overrides(assemblerType);
            if (@override is not null)
            {
                assemblers.TryAdd(requestedType, t => overrides(assemblerType));
                return assemblers[requestedType];
            }

            if (currentType.BaseType is null)
                return null;

            return ResolveSqlStatementAssemblerFactory(currentType.BaseType, requestedType);
        }
        #endregion
    }
}
