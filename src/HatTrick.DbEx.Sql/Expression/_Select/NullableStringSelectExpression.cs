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

namespace HatTrick.DbEx.Sql.Expression
{
    public class NullableStringSelectExpression : SelectExpression<string?>,
        NullableStringElement
    {
        public NullableStringSelectExpression(NullableStringElement expression)
            : base(expression)
        {

        }

        public NullableStringSelectExpression(NullableStringElement expression, string alias)
            : base(expression)
        {
            Alias = alias;
        }

        public NullableStringSelectExpression(ExpressionMediator<string?> expression)
            : base(expression)
        {

        }

        #region as
        public new NullableStringElement As(string alias)
        {
            Alias = alias;
            return this;
        }
        #endregion
    }
}