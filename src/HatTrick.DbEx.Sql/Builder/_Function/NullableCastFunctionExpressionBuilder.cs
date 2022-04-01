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
           => new(Expression, new DbTypeExpression<DbType>(DbType.Boolean));

        NullableByteCastFunctionExpression NullableCast.AsTinyInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Byte));

        NullableDateTimeCastFunctionExpression NullableCast.AsDateTime()
            => new(Expression, new DbTypeExpression<DbType>(DbType.DateTime));

        NullableDateTimeOffsetCastFunctionExpression NullableCast.AsDateTimeOffset()
            => new(Expression, new DbTypeExpression<DbType>(DbType.DateTimeOffset));

        NullableDecimalCastFunctionExpression NullableCast.AsDecimal(int precision, int scale)
            => new(Expression, new DbTypeExpression<DbType>(DbType.Decimal), precision, scale);

        NullableSingleCastFunctionExpression NullableCast.AsFloat()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Single));

        NullableGuidCastFunctionExpression NullableCast.AsUniqueIdentifier()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Guid));

        NullableInt16CastFunctionExpression NullableCast.AsSmallInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Int16));

        NullableInt32CastFunctionExpression NullableCast.AsInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Int32));

        NullableInt64CastFunctionExpression NullableCast.AsBigInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Int64));

        NullableStringCastFunctionExpression NullableCast.AsVarChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        NullableStringCastFunctionExpression NullableCast.AsChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        NullableStringCastFunctionExpression NullableCast.AsNVarChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        NullableStringCastFunctionExpression NullableCast.AsNChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        NullableTimeSpanCastFunctionExpression NullableCast.AsTime()
         => new(Expression, new DbTypeExpression<DbType>(DbType.Time));
        #endregion
    }
}
