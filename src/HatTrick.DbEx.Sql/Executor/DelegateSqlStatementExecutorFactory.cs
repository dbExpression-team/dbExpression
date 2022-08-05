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

using System;

namespace HatTrick.DbEx.Sql.Executor
{
    public class DelegateSqlStatementExecutorFactory<TDatabase> : ISqlStatementExecutorFactory<TDatabase>
        where TDatabase : class, ISqlDatabaseRuntime
    {
        #region internals
        private readonly Func<ISqlStatementExecutor<TDatabase>> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementExecutorFactory(Func<ISqlStatementExecutor<TDatabase>> factory)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public DelegateSqlStatementExecutorFactory(Func<ISqlStatementExecutorFactory<TDatabase>> factory)
        {
            if (factory is null)
                throw new ArgumentNullException(nameof(factory));

            this.factory = () => factory()?.CreateSqlStatementExecutor() ?? throw new DbExpressionException("Cannot create a Sql Statement Executor: The factory returned a null value.");
        }
        #endregion

        #region methods
        public ISqlStatementExecutor<TDatabase> CreateSqlStatementExecutor()
            => factory();
        #endregion
    }
}
