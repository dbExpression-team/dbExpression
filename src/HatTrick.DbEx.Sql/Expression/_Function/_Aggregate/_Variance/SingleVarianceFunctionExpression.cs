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
    public partial class SingleVarianceFunctionExpression :
        VarianceFunctionExpression<float>,
        SingleElement,
        IEquatable<SingleVarianceFunctionExpression>
    {
        #region constructors
        public SingleVarianceFunctionExpression(AnyElement<byte> expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(AnyElement<short> expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(AnyElement<int> expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(AnyElement<long> expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(AnyElement<double> expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(AnyElement<decimal> expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(AnyElement<float> expression) : base(expression)
        {

        }
        #endregion

        #region distinct
        public new SingleVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleVarianceFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is SingleVarianceFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
