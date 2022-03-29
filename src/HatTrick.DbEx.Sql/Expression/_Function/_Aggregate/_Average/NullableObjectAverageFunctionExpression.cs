﻿#region license
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
    public partial class NullableObjectAverageFunctionExpression :
        AverageFunctionExpression<object?>,
        NullableObjectElement<object?>,
        IEquatable<NullableObjectAverageFunctionExpression>
    {
        #region constructors
        public NullableObjectAverageFunctionExpression(AnyElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableObjectElement<object?> As(string alias)
            => new NullableObjectSelectExpression<object?>(this).As(alias);
        #endregion

        #region distinct
        public NullableObjectAverageFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableObjectAverageFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableObjectAverageFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
