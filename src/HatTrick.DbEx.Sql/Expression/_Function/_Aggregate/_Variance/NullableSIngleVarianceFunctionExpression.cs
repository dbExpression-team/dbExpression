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
    public partial class NullableSingleVarianceFunctionExpression :
        NullableVarianceFunctionExpression<float,float?>,
        NullableSingleElement,
        AnySingleElement,
        IEquatable<NullableSingleVarianceFunctionExpression>
    {
        #region constructors
        public NullableSingleVarianceFunctionExpression(NullableByteElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableInt16Element expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableInt32Element expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableInt64Element expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableDoubleElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableDecimalElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(NullableSingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public NullableSingleElement As(string alias)
            => new NullableSingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableSingleVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleVarianceFunctionExpression obj)
            => obj is NullableSingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableSingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
