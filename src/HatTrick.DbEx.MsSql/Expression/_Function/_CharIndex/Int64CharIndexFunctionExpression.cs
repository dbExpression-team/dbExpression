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
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Expression
{
    public partial class Int64CharIndexFunctionExpression :
        CharIndexFunctionExpression<long>,
        Int64Element,
        IEquatable<Int64CharIndexFunctionExpression>
    {
        #region constructors
        public Int64CharIndexFunctionExpression(AnyElement<string> pattern, AnyElement<string> expression) : base(pattern, expression)
        {

        }

        public Int64CharIndexFunctionExpression(AnyElement<string> pattern, AnyElement<string> expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(AnyElement<string> pattern, AnyElement<string> expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(StringElement pattern, AnyElement<string> expression) : base(pattern, expression)
        {

        }

        public Int64CharIndexFunctionExpression(StringElement pattern, AnyElement<string> expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(StringElement pattern, AnyElement<string> expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(StringElement pattern, StringElement expression) : base(pattern, expression)
        {

        }

        public Int64CharIndexFunctionExpression(StringElement pattern, StringElement expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(StringElement pattern, StringElement expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(AnyElement<string> pattern, StringElement expression) : base(pattern, expression)
        {

        }

        public Int64CharIndexFunctionExpression(AnyElement<string> pattern, StringElement expression, AnyElement<long> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }

        public Int64CharIndexFunctionExpression(AnyElement<string> pattern, StringElement expression, AnyElement<int> startSearchPosition) : base(pattern, expression, startSearchPosition)
        {

        }
        #endregion

        #region as
        public AnyElement<long> As(string alias)
            => new SelectExpression<long>(this).As(alias);
        #endregion

        #region equals
        public bool Equals(Int64CharIndexFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is Int64CharIndexFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
