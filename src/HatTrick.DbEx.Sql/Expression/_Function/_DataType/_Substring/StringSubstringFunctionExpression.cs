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
    public partial class StringSubstringFunctionExpression :
        SubstringFunctionExpression<string>,
        StringElement,
        IEquatable<StringSubstringFunctionExpression>
    {
        #region constructors
        public StringSubstringFunctionExpression(AnyElement<string> expression, AnyElement<int> start, AnyElement<int> length) : base(expression, start, length)
        {

        }

        public StringSubstringFunctionExpression(AnyElement<string> expression, AnyElement<int> start, AnyElement<long> length) : base(expression, start, length)
        {

        }

        public StringSubstringFunctionExpression(AnyElement<string> expression, AnyElement<long> start, AnyElement<int> length) : base(expression, start, length)
        {

        }

        public StringSubstringFunctionExpression(AnyElement<string> expression, AnyElement<long> start, AnyElement<long> length) : base(expression, start, length)
        {

        }
        #endregion

        #region as
        public AnyElement<string> As(string alias)
            => new SelectExpression<string>(this).As(alias);
        #endregion

        #region like
        public FilterExpressionSet Like(string phrase)
            => new FilterExpressionSet(new FilterExpression(this, new LikeExpression(phrase), FilterExpressionOperator.None));
        #endregion

        #region equals
        public bool Equals(StringSubstringFunctionExpression obj)
            => obj is StringSubstringFunctionExpression && base.Equals(obj);

        public override bool Equals(object obj)
            => obj is StringSubstringFunctionExpression exp && base.Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
