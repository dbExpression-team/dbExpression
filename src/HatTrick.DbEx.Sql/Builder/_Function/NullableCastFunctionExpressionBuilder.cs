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

﻿using HatTrick.DbEx.Sql.Expression;
using System.Data;

namespace HatTrick.DbEx.Sql.Builder
{
    public class NullableCastFunctionExpressionBuilder : NullableCast
    {
        #region internals
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public NullableCastFunctionExpressionBuilder(ExpressionMediator expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableBooleanCastFunctionExpression NullableCast.AsBit()
           => new NullableBooleanCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Boolean));

        NullableByteCastFunctionExpression NullableCast.AsTinyInt()
            => new NullableByteCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Byte));

        NullableDateTimeCastFunctionExpression NullableCast.AsDateTime()
            => new NullableDateTimeCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression NullableCast.AsDateTimeOffset()
            => new NullableDateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression NullableCast.AsDecimal(int precision, int scale)
            => new NullableDecimalCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Decimal));

        NullableSingleCastFunctionExpression NullableCast.AsFloat()
            => new NullableSingleCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Single));

        NullableGuidCastFunctionExpression NullableCast.AsUniqueIdentifier()
            => new NullableGuidCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Guid));

        NullableInt16CastFunctionExpression NullableCast.AsSmallInt()
            => new NullableInt16CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int16));

        NullableInt32CastFunctionExpression NullableCast.AsInt()
            => new NullableInt32CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int32));

        NullableInt64CastFunctionExpression NullableCast.AsBigInt()
            => new NullableInt64CastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Int64));

        StringCastFunctionExpression NullableCast.AsVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        StringCastFunctionExpression NullableCast.AsChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        StringCastFunctionExpression NullableCast.AsNVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        StringCastFunctionExpression NullableCast.AsNChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        NullableTimeSpanCastFunctionExpression NullableCast.AsTime()
         => new NullableTimeSpanCastFunctionExpression(Expression, new DbTypeExpression<DbType>(DbType.Time));
        #endregion
    }
}
