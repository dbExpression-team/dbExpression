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

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlStatementAssemblerFactory<TDatabase> : ISqlStatementAssemblerFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<Type, ISqlStatementAssembler<TDatabase>> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementAssemblerFactory(Func<Type, ISqlStatementAssembler<TDatabase>> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
        #endregion

        #region methods
        public ISqlStatementAssembler<TDatabase> CreateSqlStatementAssembler(Type queryType)
            => factory(typeof(ISqlStatementAssembler<,>).MakeGenericType(new Type[] { typeof(TDatabase), queryType }));

        public ISqlStatementAssembler<TDatabase, TQuery> CreateSqlStatementAssembler<TQuery>()
            where TQuery : QueryExpression
            => (CreateSqlStatementAssembler(typeof(TQuery)) as ISqlStatementAssembler<TDatabase, TQuery>)!;
        #endregion
    }
}
