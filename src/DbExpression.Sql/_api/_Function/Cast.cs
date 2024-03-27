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

﻿using DbExpression.Sql.Expression;
using System.Data;

namespace DbExpression.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Cast
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Bit"/>
        /// </summary>
        BooleanCastFunctionExpression AsBit();
        
        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.TinyInt"/>
        /// </summary>
        ByteCastFunctionExpression AsTinyInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTime"/>
        /// </summary>
        DateTimeCastFunctionExpression AsDateTime();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTimeOffset"/>
        /// </summary>
        DateTimeOffsetCastFunctionExpression AsDateTimeOffset();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Decimal"/>
        /// </summary>
        DecimalCastFunctionExpression AsDecimal(int precision, int scale);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Float"/>
        /// </summary>
        SingleCastFunctionExpression AsFloat();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.UniqueIdentifier"/>
        /// </summary>
        GuidCastFunctionExpression AsUniqueIdentifier();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.SmallInt"/>
        /// </summary>
        Int16CastFunctionExpression AsSmallInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Int"/>
        /// </summary>
        Int32CastFunctionExpression AsInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.BigInt"/>
        /// </summary>
        Int64CastFunctionExpression AsBigInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.VarChar"/>
        /// </summary>
        StringCastFunctionExpression AsVarChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Char"/>
        /// </summary>
        StringCastFunctionExpression AsChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.NVarChar"/>
        /// </summary>
        StringCastFunctionExpression AsNVarChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.NChar"/>
        /// </summary>
        StringCastFunctionExpression AsNChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Time"/>
        /// </summary>
        TimeSpanCastFunctionExpression AsTime();
    }
}
