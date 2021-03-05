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
    public partial class NullableByteMinimumFunctionExpression :
        NullableMinimumFunctionExpression<byte,byte?>,
        NullableByteElement,
        AnyByteElement,
        IEquatable<NullableByteMinimumFunctionExpression>
    {
        #region constructors
        public NullableByteMinimumFunctionExpression(NullableByteElement expression) 
            : base(expression)
        {

        }
        #endregion

        #region as
        public NullableByteElement As(string alias)
            => new NullableByteSelectExpression(this).As(alias);
        #endregion

        #region distinct
        public NullableByteMinimumFunctionExpression Distinct()
        {
            IsDistinct = true;
            return this;
        }
        #endregion

        #region equals
        public bool Equals(NullableByteMinimumFunctionExpression obj)
            => obj is NullableByteMinimumFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableByteMinimumFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
