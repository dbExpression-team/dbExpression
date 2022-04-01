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
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class EnumCoalesceFunctionExpression<TEnum> :
        CoalesceFunctionExpression<TEnum>,
        EnumElement<TEnum>,
        IEquatable<EnumCoalesceFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public EnumCoalesceFunctionExpression(IList<AnyElement<TEnum?>> expressions, AnyElement<TEnum> termination) : base(expressions.Concat(new AnyElement[1] { termination }).ToList())
        {

        }

        public EnumCoalesceFunctionExpression(IList<AnyElement<TEnum>> expressions, AnyElement<TEnum> termination) : base(expressions.Concat(new AnyElement[1] { termination }).ToList())
        {

        }

        public EnumCoalesceFunctionExpression(IList<EnumElement<TEnum>> expressions, AnyElement<TEnum> termination) : base(expressions.Concat(new AnyElement[1] { termination }).ToList())
        {

        }

        public EnumCoalesceFunctionExpression(IList<NullableEnumElement<TEnum>> expressions, AnyElement<TEnum> termination) : base(expressions.Concat(new AnyElement[1] { termination }).ToList())
        {

        }
        #endregion

        #region equals
        public bool Equals(EnumCoalesceFunctionExpression<TEnum>? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is EnumCoalesceFunctionExpression<TEnum> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
