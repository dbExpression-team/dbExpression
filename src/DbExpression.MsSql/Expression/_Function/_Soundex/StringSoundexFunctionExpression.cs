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

using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.MsSql.Expression
{
    public partial class StringSoundexFunctionExpression :
        SoundexFunctionExpression<string>,
        StringElement,
        IEquatable<StringSoundexFunctionExpression>
    {
        #region constructors
        public StringSoundexFunctionExpression(StringElement expression) : base(expression)
        {

        }
        #endregion

        #region as
        public new StringElement As(string alias)
            => new StringSelectExpression(this, alias);
        #endregion

        #region like
        public FilterExpression Like(string phrase)
            => new FilterExpression<bool>(this, new LikeExpression(phrase), FilterExpressionOperator.None);
        #endregion

        #region equals
        public bool Equals(StringSoundexFunctionExpression? obj)
            => obj is not null && base.Equals(obj);

        public override bool Equals(object? obj)
            => obj is StringSoundexFunctionExpression exp && Equals(exp);

        public override int GetHashCode()
            => base.GetHashCode();
        #endregion
    }
}
