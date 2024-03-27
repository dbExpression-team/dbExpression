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

namespace DbExpression.Sql.Expression
{
    public partial class SingleExpFunctionExpression :
        ExpFunctionExpression<float>,
        SingleElement,
        IEquatable<SingleExpFunctionExpression>
    {
        #region constructors
        public SingleExpFunctionExpression(AnyElement<byte> expression) : base(expression)
        {

        }

        public SingleExpFunctionExpression(AnyElement<short> expression) : base(expression)
        {

        }

        public SingleExpFunctionExpression(AnyElement<int> expression) : base(expression)
        {

        }

        public SingleExpFunctionExpression(AnyElement<long> expression) : base(expression)
        {

        }

        public SingleExpFunctionExpression(AnyElement<double> expression) : base(expression)
        {

        }

        public SingleExpFunctionExpression(AnyElement<decimal> expression) : base(expression)
        {

        }

        public SingleExpFunctionExpression(AnyElement<float> expression) : base(expression)
        {

        }
        #endregion

        #region equals
        public bool Equals(SingleExpFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is SingleExpFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
