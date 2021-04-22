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

﻿using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;
using System.Data;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlNullableCastFunctionExpressionBuilder : MsSqlNullableCast
    {
        #region internals
        public IExpressionElement Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlNullableCastFunctionExpressionBuilder(IExpressionElement expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableBooleanCastFunctionExpression NullableCast.AsBit()
            => new NullableBooleanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        NullableByteCastFunctionExpression NullableCast.AsTinyInt()
            => new NullableByteCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        NullableDateTimeCastFunctionExpression NullableCast.AsDateTime()
            => new NullableDateTimeCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression NullableCast.AsDateTimeOffset()
            => new NullableDateTimeOffsetCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression NullableCast.AsDecimal(int precision, int scale)
            => new NullableDecimalCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Decimal));

        NullableDoubleCastFunctionExpression MsSqlNullableCast.AsMoney()
            => new NullableDoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Money));

        NullableDoubleCastFunctionExpression MsSqlNullableCast.AsSmallMoney()
            => new NullableDoubleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallMoney));

        NullableSingleCastFunctionExpression NullableCast.AsFloat()
            => new NullableSingleCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Float));

        NullableGuidCastFunctionExpression NullableCast.AsUniqueIdentifier()
            => new NullableGuidCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.UniqueIdentifier));

        NullableInt16CastFunctionExpression NullableCast.AsSmallInt()
            => new NullableInt16CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallInt));

        NullableInt32CastFunctionExpression NullableCast.AsInt()
            => new NullableInt32CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Int));

        NullableInt64CastFunctionExpression NullableCast.AsBigInt()
            => new NullableInt64CastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.BigInt));

        StringCastFunctionExpression NullableCast.AsVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.VarChar), size);

        StringCastFunctionExpression NullableCast.AsChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Char), size);

        StringCastFunctionExpression NullableCast.AsNVarChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NVarChar), size);

        StringCastFunctionExpression NullableCast.AsNChar(int size)
            => new StringCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NChar), size);

        NullableTimeSpanCastFunctionExpression NullableCast.AsTime()
            => new NullableTimeSpanCastFunctionExpression(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Time));
        #endregion
    }
}
