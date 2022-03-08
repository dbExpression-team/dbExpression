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
    public partial class NullableEnumCoalesceFunctionExpression<TEnum> :
        NullableCoalesceFunctionExpression<TEnum,TEnum?>,
        NullableEnumElement<TEnum>,
        IEquatable<NullableEnumCoalesceFunctionExpression<TEnum>>
        where TEnum : struct, Enum, IComparable
    {
        #region constructors
        public NullableEnumCoalesceFunctionExpression(IList<NullableEnumElement<TEnum>> expressions) 
            : base(expressions)
        {

        }

        public NullableEnumCoalesceFunctionExpression(IList<NullableEnumElement<TEnum>> expressions, AnyElement<TEnum> termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }) ?? new IExpressionElement[1] { termination })
        {

        }

        public NullableEnumCoalesceFunctionExpression(IList<NullableEnumElement<TEnum>> expressions, AnyElement<TEnum?> termination) 
            : base(expressions?.Concat(new IExpressionElement[1] { termination }) ?? new IExpressionElement[1] { termination })
        {

        }
        #endregion

        #region as
        public AnyElement<TEnum?> As(string alias)
            => new SelectExpression<TEnum?>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableEnumCoalesceFunctionExpression<TEnum>? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableEnumCoalesceFunctionExpression<TEnum> exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
