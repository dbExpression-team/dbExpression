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
    public partial class SinglePopulationStandardDeviationFunctionExpression :
        PopulationStandardDeviationFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SinglePopulationStandardDeviationFunctionExpression>
    {
        #region constructors
        public SinglePopulationStandardDeviationFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(Int16Element expression) : base(expression)
        {

        }
        public SinglePopulationStandardDeviationFunctionExpression(Int32Element expression) : base(expression)
        {
        }

        public SinglePopulationStandardDeviationFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SinglePopulationStandardDeviationFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public SinglePopulationStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SinglePopulationStandardDeviationFunctionExpression obj)
            => obj is SinglePopulationStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SinglePopulationStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
