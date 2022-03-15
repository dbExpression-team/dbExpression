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

using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public class DelegateSqlStatementBuilderFactory : ISqlStatementBuilderFactory
    {
        #region internals
        private readonly Func<SqlDatabaseRuntimeConfiguration, QueryExpression, ISqlStatementBuilder> factory;
        #endregion

        #region constructors
        public DelegateSqlStatementBuilderFactory(Func<SqlDatabaseRuntimeConfiguration, QueryExpression, ISqlStatementBuilder> factory)
        {
            this.factory = factory ?? throw new DbExpressionConfigurationException($"{nameof(factory)} is required to initialize a sql statement builder.");
        }
        #endregion

        #region methods
        public ISqlStatementBuilder CreateSqlStatementBuilder(SqlDatabaseRuntimeConfiguration database, QueryExpression expression)
            => factory(database, expression) ?? throw new DbExpressionConfigurationException("Could not resolve a statement builder, please ensure an statement builder factory has been properly registered.");
        #endregion
    }
}
