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
    public abstract class SqlStatementAssemblerFactory : ISqlStatementAssemblerFactory
    {
        #region internals
        private readonly ConcurrentDictionary<Type, Func<ISqlStatementAssembler>> statementAssemblers = new ConcurrentDictionary<Type, Func<ISqlStatementAssembler>>();
        #endregion

        #region methods
        public ISqlStatementAssembler CreateSqlStatementAssembler(QueryExpression expression)
            => ResolveAssemblerFactory(expression.GetType());

        public virtual void RegisterStatementAssembler<T, U>()
            where T : QueryExpression
            where U : class, ISqlStatementAssembler, new()
            => RegisterStatementAssembler<T, U>(() => new U());

        public virtual void RegisterStatementAssembler<T, U>(U assembler)
            where T : QueryExpression
            where U : class, ISqlStatementAssembler
            => RegisterStatementAssembler<T, U>(() => assembler);

        public virtual void RegisterStatementAssembler<T, U>(Func<U> assemblerFactory)
            where T : QueryExpression
            where U : class, ISqlStatementAssembler
            => statementAssemblers.AddOrUpdate(typeof(T), assemblerFactory, (t, f) => assemblerFactory);

        private ISqlStatementAssembler ResolveAssemblerFactory(Type current)
        {
            var factory = ResolveAssemblerFactory(current, current);
            return factory is object ? factory() : null;
        }

        private Func<ISqlStatementAssembler> ResolveAssemblerFactory(Type current, Type original)
        {
            if (statementAssemblers.TryGetValue(current, out Func<ISqlStatementAssembler> factory))
                return factory;

            if (current.BaseType is null)
                return null;

            factory = ResolveAssemblerFactory(current.BaseType, original);

            if (factory is object && current == original)
                //reduce runtime recursion by "registering" the original with the found factory
                statementAssemblers.TryAdd(original, factory);

            return ResolveAssemblerFactory(current.BaseType, original);
        }
        #endregion
    }
}
