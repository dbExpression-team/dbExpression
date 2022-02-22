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
    public partial class NullableTimeSpanIsNullFunctionExpression :
        NullableIsNullFunctionExpression<TimeSpan,TimeSpan?>,
        NullableTimeSpanElement,
        IEquatable<NullableTimeSpanIsNullFunctionExpression>
    {
        #region constructors
        public NullableTimeSpanIsNullFunctionExpression(AnyElement<TimeSpan?> expression, AnyElement<TimeSpan?> value)
            : base(expression, value)
        {

        }
        #endregion

        #region as
        public AnyElement<TimeSpan?> As(string alias)
            => new SelectExpression<TimeSpan?>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableTimeSpanIsNullFunctionExpression obj)
            => obj is NullableTimeSpanIsNullFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableTimeSpanIsNullFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
