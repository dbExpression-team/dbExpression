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
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public abstract class QueryExpressionBuilder :
        ITerminationExpressionBuilder,
        IQueryExpressionProvider,
        IRuntimeSqlDatabaseConfigurationProvider
    {
        #region internals
        protected RuntimeSqlDatabaseConfiguration Configuration { get; private set; }
        private readonly QueryExpression expression;
        #endregion

        #region interface
        QueryExpression IQueryExpressionProvider.Expression => expression;
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabaseConfigurationProvider.Configuration => Configuration;
        #endregion

        #region constructors
        protected QueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, QueryExpression expression)
        {
            this.Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.expression = expression ?? throw new ArgumentNullException(nameof(expression));
        }
        #endregion

        #region methods
        protected T GetQueryExpression<T>()
            where T : QueryExpression
        {
            return expression as T ?? throw new DbExpressionConfigurationException($"Query expression is type '{expression.GetType()}', the type was expected to be the requested type of '{typeof(T)}'.");
        }
        #endregion
    }
}
