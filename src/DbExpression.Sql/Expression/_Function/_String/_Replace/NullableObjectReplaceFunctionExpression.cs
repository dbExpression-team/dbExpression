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
using System.Collections.Generic;

namespace DbExpression.Sql.Expression
{
    public partial class NullableObjectReplaceFunctionExpression :
        ReplaceFunctionExpression<object?>,
        NullableObjectElement,
        IEquatable<NullableObjectReplaceFunctionExpression>
    {
        #region constructors
        public NullableObjectReplaceFunctionExpression(AnyStringElement expression, AnyElement pattern, AnyElement replacement) : base(expression, pattern, replacement)
        {

        }

        public NullableObjectReplaceFunctionExpression(AnyElement<string?> expression, AnyElement pattern, AnyElement replacement) : base(expression, pattern, replacement)
        {

        }
        #endregion

        #region as
        public new NullableObjectElement As(string alias)
            => new NullableObjectSelectExpression(this, alias);
        #endregion

        #region equals
        public bool Equals(NullableObjectReplaceFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableObjectReplaceFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
