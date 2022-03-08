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
    public partial class NullableSinglePopulationStandardDeviationFunctionExpression :
        NullablePopulationStandardDeviationFunctionExpression<float,float?>,
        NullableSingleElement,
        IEquatable<NullableSinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<byte?> expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<short?> expression) : base(expression)
        {

        }
        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<int?> expression) : base(expression)
        {
        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<long?> expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<double?> expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<decimal?> expression) : base(expression)
        {

        }

        public NullableSinglePopulationStandardDeviationFunctionExpression(AnyElement<float?> expression) : base(expression)
        {

        }
        #endregion

        #region as
        public AnyElement<float?> As(string alias)
            => new SelectExpression<float?>(this).As(alias);
        #endregion

        #region distinct
        public NullableSinglePopulationStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableSinglePopulationStandardDeviationFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is NullableSinglePopulationStandardDeviationFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
