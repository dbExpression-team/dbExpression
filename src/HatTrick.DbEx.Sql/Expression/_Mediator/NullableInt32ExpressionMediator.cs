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
    public partial class NullableInt32ExpressionMediator :
        NullableExpressionMediator<int,int?>,
        NullableInt32Element,
        AnyInt32Element,
        IEquatable<NullableInt32ExpressionMediator>
    {
        #region constructors
        private NullableInt32ExpressionMediator()
        {
        }

        public NullableInt32ExpressionMediator(IExpressionElement expression) : base(expression, typeof(int?))
        {
        }

        protected NullableInt32ExpressionMediator(IExpressionElement expression, string alias) : base(expression, typeof(int?), alias)
        {
        }
        #endregion

        #region as
        public NullableInt32Element As(string alias)
            => new NullableInt32SelectExpression(this).As(alias);
        #endregion

        #region equals
        public bool Equals(NullableInt32ExpressionMediator obj)
            => obj is NullableInt32ExpressionMediator && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is NullableInt32ExpressionMediator exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
