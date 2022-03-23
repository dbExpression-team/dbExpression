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

using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class NullableObjectRoundFunctionExpression :
        RoundFunctionExpression<object?>,
        NullableObjectElement<object?>,
        IEquatable<NullableObjectRoundFunctionExpression>
    {
        #region constructors
        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyElement length) : base(expression, length)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyElement length, AnyElement function) : base(expression, length, function)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, IntegralNumericElement length) : base(expression, length)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, IntegralNumericElement length, AnyElement function) : base(expression, length, function)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, IntegralNumericElement length, IntegralNumericElement function) : base(expression, length, function)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyElement length, NullableIntegralNumericElement function) : base(expression, length, function)
        {

        }
        #endregion

        #region as
        public NullableObjectElement<object?> As(string alias)
            => new NullableObjectSelectExpression<object?>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableObjectRoundFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableObjectRoundFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
