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
    public partial class NullableSingleVarianceFunctionExpression :
        NullableVarianceFunctionExpression<float,float?>,
        NullableSingleElement,
        IEquatable<NullableSingleVarianceFunctionExpression>
    {
        #region constructors
        public NullableSingleVarianceFunctionExpression(NullableNumericElement expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<byte?> expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<short?> expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<int?> expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<long?> expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<double?> expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<decimal?> expression) : base(expression)
        {

        }

        public NullableSingleVarianceFunctionExpression(AnyElement<float?> expression) : base(expression)
        {

        }
        #endregion

        #region distinct
        public new NullableSingleVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSingleVarianceFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableSingleVarianceFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
