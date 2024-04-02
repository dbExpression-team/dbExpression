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

using System;

namespace DbExpression.Sql.Expression
{
    public partial class NullableStringLTrimFunctionExpression :
        NullableLTrimFunctionExpression<string,string?>,
        NullableStringElement,
        IEquatable<NullableStringLTrimFunctionExpression>
    {
        #region constructors
        public NullableStringLTrimFunctionExpression(AnyElement<string?> expression) 
            : base(expression)
        {

        }

        public NullableStringLTrimFunctionExpression(AnyStringElement expression)
            : base(expression)
        {

        }
        #endregion

        #region as
        public new NullableStringElement As(string alias)
            => new NullableStringSelectExpression(this, alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase)
            => new FilterExpression<bool>(this, new LikeExpression(phrase), FilterExpressionOperator.None);
        #endregion

        #region equals
        public bool Equals(NullableStringLTrimFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableStringLTrimFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
