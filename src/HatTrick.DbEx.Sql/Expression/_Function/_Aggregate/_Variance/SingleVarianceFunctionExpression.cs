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
        AnySingleElement,
        IEquatable<SingleVarianceFunctionExpression>
    {
        #region constructors
        public SingleVarianceFunctionExpression(ByteElement expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(Int16Element expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(Int32Element expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(Int64Element expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(DoubleElement expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(DecimalElement expression) : base(expression)
        {

        }

        public SingleVarianceFunctionExpression(SingleElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public SingleElement As(string alias)
            => new SingleSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public SingleVarianceFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(SingleVarianceFunctionExpression obj)
            => obj is SingleVarianceFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is SingleVarianceFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
