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
        NullableObjectElement,
        IEquatable<NullableObjectRoundFunctionExpression>
    {
        #region constructors
        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyElement length) : base(expression, length)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyElement length, AnyElement function) : base(expression, length, function)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyNumericElement length) : base(expression, length)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyNumericElement length, AnyElement function) : base(expression, length, function)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyNumericElement length, AnyNumericElement function) : base(expression, length, function)
        {

        }

        public NullableObjectRoundFunctionExpression(AnyElement expression, AnyElement length, NullableAnyNumericElement function) : base(expression, length, function)
        {

        }
        #endregion

        #region as
        public new NullableObjectElement As(string alias)
            => new NullableObjectSelectExpression(this, alias);
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
