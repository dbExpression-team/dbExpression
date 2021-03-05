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
    public partial class SingleStandardDeviationFunctionExpression :
        StandardDeviationFunctionExpression<float>,
        SingleElement,
        AnySingleElement,
        IEquatable<SingleStandardDeviationFunctionExpression>
    {
        #region constructors
        public SingleStandardDeviationFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int32Element expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SingleStandardDeviationFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public SingleStandardDeviationFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleStandardDeviationFunctionExpression obj)
            => obj is SingleStandardDeviationFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleStandardDeviationFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
