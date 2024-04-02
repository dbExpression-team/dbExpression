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

using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System.Collections.Generic;

namespace DbExpression.MsSql.Expression
{
    public abstract class CharIndexFunctionExpression<TValue> : CharIndexFunctionExpression,
        IExpressionElement<TValue>,
        AnyElement<TValue>
    {
        #region constructors
        protected CharIndexFunctionExpression(AnyElement<string> pattern, AnyElement<string> expression) : base(pattern, expression, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(AnyElement<string> pattern, AnyElement<string> expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(AnyElement<string> pattern, AnyElement<string> expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(StringElement pattern, AnyElement<string> expression) : base(pattern, expression, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(StringElement pattern, AnyElement<string> expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(StringElement pattern, AnyElement<string> expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(StringElement pattern, StringElement expression) : base(pattern, expression, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(StringElement pattern, StringElement expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(StringElement pattern, StringElement expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(AnyElement<string> pattern, StringElement expression) : base(pattern, expression, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(AnyElement<string> pattern, StringElement expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }

        protected CharIndexFunctionExpression(AnyElement<string> pattern, StringElement expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition, typeof(TValue))
        {

        }
        #endregion

        #region in
        public FilterExpression In(params TValue[] values)
           => new FilterExpression<bool>(this, new InExpression<TValue>(this, values), FilterExpressionOperator.None);

        public FilterExpression In(IEnumerable<TValue> values)
            => new FilterExpression<bool>(this, new InExpression<TValue>(this, values), FilterExpressionOperator.None);
        #endregion

        #region as
        public AliasedElement<TValue> As(string alias)
            => new SelectExpression<TValue>(this, alias);
        #endregion
    }
}
