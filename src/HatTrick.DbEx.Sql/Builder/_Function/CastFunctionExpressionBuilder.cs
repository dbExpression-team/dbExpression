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
    public class CastFunctionExpressionBuilder : Cast
    {
        #region internals
        public ExpressionMediator Expression { get; private set; }
        #endregion

        #region constructors
        public CastFunctionExpressionBuilder(ExpressionMediator expression)
        {
            Expression = expression;
        }
        #endregion

        #region methods
        BooleanCastFunctionExpression Cast.AsBit()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Boolean));

        ByteCastFunctionExpression Cast.AsTinyInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Byte));

        DateTimeCastFunctionExpression Cast.AsDateTime()
            => new(Expression, new DbTypeExpression<DbType>(DbType.DateTime));

        DateTimeOffsetCastFunctionExpression Cast.AsDateTimeOffset()
            => new(Expression, new DbTypeExpression<DbType>(DbType.DateTimeOffset));

        DecimalCastFunctionExpression Cast.AsDecimal(int precision, int scale)
            => new(Expression, new DbTypeExpression<DbType>(DbType.Decimal), precision, scale);

        SingleCastFunctionExpression Cast.AsFloat()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Single));

        GuidCastFunctionExpression Cast.AsUniqueIdentifier()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Guid));

        Int16CastFunctionExpression Cast.AsSmallInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Int16));

        Int32CastFunctionExpression Cast.AsInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Int32));

        Int64CastFunctionExpression Cast.AsBigInt()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Int64));

        StringCastFunctionExpression Cast.AsVarChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        StringCastFunctionExpression Cast.AsChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.String), size);

        StringCastFunctionExpression Cast.AsNVarChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        StringCastFunctionExpression Cast.AsNChar(int size)
            => new(Expression, new DbTypeExpression<DbType>(DbType.AnsiString), size);

        TimeSpanCastFunctionExpression Cast.AsTime()
            => new(Expression, new DbTypeExpression<DbType>(DbType.Time));
        #endregion
    }
}
