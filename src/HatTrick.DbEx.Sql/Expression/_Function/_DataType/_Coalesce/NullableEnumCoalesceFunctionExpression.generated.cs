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

#nullable enable

namespace HatTrick.DbEx.Sql.Expression
{
    public partial class NullableEnumCoalesceFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumCoalesceFunctionExpression<TEnum> a) => new(a);
        #endregion
        
        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableEnumCoalesceFunctionExpression<TEnum> a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumCoalesceFunctionExpression<TEnum> a, DBNull b) => new(new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(b), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new(new FilterExpression<bool?>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableEnumCoalesceFunctionExpression<TEnum> b) => new(new FilterExpression<bool?>(new LiteralExpression<TEnum?>(a), b, FilterExpressionOperator.NotEqual));
        #endregion

        #region TEnum
        #endregion

        #region mediator
        #endregion

        #region alias
        #endregion
        #endregion
    }
}
