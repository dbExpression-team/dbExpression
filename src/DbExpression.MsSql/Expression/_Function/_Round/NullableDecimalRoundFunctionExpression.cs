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
using DbExpression.Sql;
using DbExpression.Sql.Expression;

namespace DbExpression.MsSql.Expression
{
    public partial class NullableDecimalRoundFunctionExpression :
        NullableRoundFunctionExpression<decimal,decimal?>,
        NullableDecimalElement,
        IEquatable<NullableDecimalRoundFunctionExpression>
    {
        #region constructors
        public NullableDecimalRoundFunctionExpression(AnyElement<decimal?> expression, AnyElement length) : base(expression, length)
        {

        }

        public NullableDecimalRoundFunctionExpression(AnyElement<decimal?> expression, AnyElement length, AnyElement function) : base(expression, length, function)
        {

        }
        #endregion

        #region equals
        public bool Equals(NullableDecimalRoundFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableDecimalRoundFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
