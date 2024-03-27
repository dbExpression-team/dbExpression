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

﻿using DbExpression.Sql;
using DbExpression.Sql.Expression;
using System.Data;

namespace DbExpression.MsSql.Builder
{
    public class MsSqlNullableCastFunctionExpressionBuilder : MsSqlNullableCast
    {
        #region internals
        public AnyElement Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlNullableCastFunctionExpressionBuilder(AnyElement expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        NullableBooleanCastFunctionExpression NullableCast.AsBit()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        NullableByteCastFunctionExpression NullableCast.AsTinyInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        NullableDateTimeCastFunctionExpression NullableCast.AsDateTime()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression NullableCast.AsDateTimeOffset()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression NullableCast.AsDecimal(int precision, int scale)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Decimal), precision, scale);

        NullableDoubleCastFunctionExpression MsSqlNullableCast.AsMoney()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Money));

        NullableDoubleCastFunctionExpression MsSqlNullableCast.AsSmallMoney()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallMoney));

        NullableSingleCastFunctionExpression NullableCast.AsFloat()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Float));

        NullableGuidCastFunctionExpression NullableCast.AsUniqueIdentifier()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.UniqueIdentifier));

        NullableInt16CastFunctionExpression NullableCast.AsSmallInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallInt));

        NullableInt32CastFunctionExpression NullableCast.AsInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Int));

        NullableInt64CastFunctionExpression NullableCast.AsBigInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.BigInt));

        NullableStringCastFunctionExpression NullableCast.AsVarChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.VarChar), size);

        NullableStringCastFunctionExpression NullableCast.AsChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Char), size);

        NullableStringCastFunctionExpression NullableCast.AsNVarChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NVarChar), size);

        NullableStringCastFunctionExpression NullableCast.AsNChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NChar), size);

        NullableTimeSpanCastFunctionExpression NullableCast.AsTime()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Time));
        #endregion
    }
}
