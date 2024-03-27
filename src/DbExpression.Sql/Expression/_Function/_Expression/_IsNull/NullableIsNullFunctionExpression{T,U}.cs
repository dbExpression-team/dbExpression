#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

﻿using System;
using System.Collections.Generic;

namespace DbExpression.Sql.Expression
{
    public abstract class NullableIsNullFunctionExpression<TValue, TNullableValue> : IsNullFunctionExpression,
        IExpressionElement<TValue, TNullableValue>,
        AnyElement<TNullableValue>
        where TValue : IComparable
    {
        #region constructors
        protected NullableIsNullFunctionExpression(IExpressionElement expression, IExpressionElement value)
            : base(expression, typeof(TNullableValue), value)
        {

        }
        #endregion

        #region in
        public FilterExpression In(params TNullableValue[] values)
           => new FilterExpression<bool>(this, new InExpression<TNullableValue>(this, values), FilterExpressionOperator.None);

        public FilterExpression In(IEnumerable<TNullableValue> values)
            => new FilterExpression<bool>(this, new InExpression<TNullableValue>(this, values), FilterExpressionOperator.None);
        #endregion

        #region as
        public AliasedElement<TNullableValue> As(string alias)
            => new SelectExpression<TNullableValue>(this, alias);
        #endregion
    }
}
