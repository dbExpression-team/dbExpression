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
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder
{
    public class StoredProcedureQueryExpressionBuilder : QueryExpressionBuilder,
        StoredProcedureContinuation,
        StoredProcedureTermination,
        SelectDynamicStoredProcedureContinuation,
        SelectDynamicsStoredProcedureContinuation
    {
        #region internals
        protected StoredProcedureQueryExpression Expression { get; private set; }
        #endregion

        #region constructors
        public StoredProcedureQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration config, StoredProcedureQueryExpression expression, StoredProcedureExpression entity)
            : base(config, expression)
        {
            Expression = expression ?? throw new ArgumentNullException(nameof(expression));
            Expression.BaseEntity = entity ?? throw new ArgumentNullException(nameof(entity));
        }
        #endregion

        #region methods
        SelectValueStoredProcedureContinuation<TValue> StoredProcedureContinuation.GetValue<TValue>()
            => new SelectValueStoredProcedureQueryExpressionBuilder<TValue>(Configuration, Expression);

        SelectValuesStoredProcedureContinuation<TValue> StoredProcedureContinuation.GetValues<TValue>()
            => new SelectValuesStoredProcedureQueryExpressionBuilder<TValue>(Configuration, Expression);

        MapValuesStoredProcedureContinuation StoredProcedureContinuation.MapValues(Action<ISqlFieldReader> row)
            => new MapValuesStoredProcedureQueryExpressionBuilder(Configuration, Expression, row);

        SelectDynamicStoredProcedureContinuation StoredProcedureContinuation.GetValue()
            => this;

        SelectDynamicsStoredProcedureContinuation StoredProcedureContinuation.GetValues()
            => this;
        #endregion
    }
}
