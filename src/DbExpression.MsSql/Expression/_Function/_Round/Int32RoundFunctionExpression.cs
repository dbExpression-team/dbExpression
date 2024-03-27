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
    public partial class Int32RoundFunctionExpression :
        RoundFunctionExpression<int>,
        Int32Element,
        IEquatable<Int32RoundFunctionExpression>
    {
        #region constructors
        public Int32RoundFunctionExpression(AnyElement<byte> expression, AnyElement length) : base(expression, length)
        {

        }

        public Int32RoundFunctionExpression(AnyElement<byte> expression, AnyElement length, AnyElement function) : base(expression, length, function)
        {

        }

        public Int32RoundFunctionExpression(AnyElement<short> expression, AnyElement length) : base(expression, length)
        {

        }

        public Int32RoundFunctionExpression(AnyElement<short> expression, AnyElement length, AnyElement function) : base(expression, length, function)
        {

        }

        public Int32RoundFunctionExpression(AnyElement<int> expression, AnyElement length) : base(expression, length)
        {

        }

        public Int32RoundFunctionExpression(AnyElement<int> expression, AnyElement length, AnyElement function) : base(expression, length, function)
        {

        }
        #endregion

        #region equals
        public bool Equals(Int32RoundFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is Int32RoundFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
