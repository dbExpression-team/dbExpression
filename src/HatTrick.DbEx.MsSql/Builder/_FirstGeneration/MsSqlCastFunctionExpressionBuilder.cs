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
    public class MsSqlCastFunctionExpressionBuilder : MsSqlCast
    {
        #region internals
        public AnyElement Expression { get; private set; }
        #endregion

        #region constructors
        public MsSqlCastFunctionExpressionBuilder(AnyElement expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        BooleanCastFunctionExpression Cast.AsBit()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        ByteCastFunctionExpression Cast.AsTinyInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Bit));

        DateTimeCastFunctionExpression Cast.AsDateTime()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTime));

        DateTimeOffsetCastFunctionExpression Cast.AsDateTimeOffset()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.DateTimeOffset));

        DecimalCastFunctionExpression Cast.AsDecimal(int precision, int scale)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Decimal), precision, scale);

        DoubleCastFunctionExpression MsSqlCast.AsMoney()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Money));

        DoubleCastFunctionExpression MsSqlCast.AsSmallMoney()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallMoney));

        SingleCastFunctionExpression Cast.AsFloat()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Float));

        GuidCastFunctionExpression Cast.AsUniqueIdentifier()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.UniqueIdentifier));

        Int16CastFunctionExpression Cast.AsSmallInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.SmallInt));

        Int32CastFunctionExpression Cast.AsInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Int));

        Int64CastFunctionExpression Cast.AsBigInt()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.BigInt));

        StringCastFunctionExpression Cast.AsVarChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.VarChar), size);

        StringCastFunctionExpression Cast.AsChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Char), size);

        StringCastFunctionExpression Cast.AsNVarChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NVarChar), size);

        StringCastFunctionExpression Cast.AsNChar(int size)
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.NChar), size);

        TimeSpanCastFunctionExpression Cast.AsTime()
            => new(Expression, new DbTypeExpression<SqlDbType>(SqlDbType.Time));
        #endregion
    }
}
