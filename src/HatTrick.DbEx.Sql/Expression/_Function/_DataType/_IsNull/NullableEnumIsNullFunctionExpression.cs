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

using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumIsNullFunctionExpression<TEnum> :
        NullableIsNullFunctionExpression<TEnum,TEnum?>,
        NullableEnumElement<TEnum>,
        AnyEnumElement<TEnum>,
        IEquatable<NullableEnumIsNullFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumIsNullFunctionExpression(AnyEnumElement<TEnum> expression, NullableEnumElement<TEnum> value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public NullableEnumElement<TEnum> As(string alias)
            => new NullableEnumSelectExpression<TEnum>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableEnumIsNullFunctionExpression<TEnum> obj)
            => obj is NullableEnumIsNullFunctionExpression<TEnum> && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableEnumIsNullFunctionExpression<TEnum> exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
