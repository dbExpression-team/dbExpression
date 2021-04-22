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
    public partial class NullableEnumIsNullFunctionExpression<TEnum>
    {
        #region implicit operators
        public static implicit operator NullableEnumExpressionMediator<TEnum>(NullableEnumIsNullFunctionExpression<TEnum> a) => new NullableEnumExpressionMediator<TEnum>(new NullableEnumExpressionMediator<TEnum>(a));
        #endregion
        
        #region filter operators
        #region DBNull
        public static FilterExpressionSet operator ==(NullableEnumIsNullFunctionExpression<TEnum> a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(DBNull.Value), FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(NullableEnumIsNullFunctionExpression<TEnum> a, DBNull b) => new FilterExpressionSet(new FilterExpression<bool?>(a, new LiteralExpression<TEnum?>(DBNull.Value), FilterExpressionOperator.NotEqual));
        public static FilterExpressionSet operator ==(DBNull a, NullableEnumIsNullFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TEnum?>(DBNull.Value), b, FilterExpressionOperator.Equal));
        public static FilterExpressionSet operator !=(DBNull a, NullableEnumIsNullFunctionExpression<TEnum> b) => new FilterExpressionSet(new FilterExpression<bool?>(new LiteralExpression<TEnum?>(DBNull.Value), b, FilterExpressionOperator.NotEqual));
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
