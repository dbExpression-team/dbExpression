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

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface NullableCast
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Bit"/>
        /// </summary>
        NullableBooleanCastFunctionExpression AsBit();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.TinyInt"/>
        /// </summary>
        NullableByteCastFunctionExpression AsTinyInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTime"/>
        /// </summary>
        NullableDateTimeCastFunctionExpression AsDateTime();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.DateTimeOffset"/>
        /// </summary>
        NullableDateTimeOffsetCastFunctionExpression AsDateTimeOffset();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Decimal"/>
        /// </summary>
        NullableDecimalCastFunctionExpression AsDecimal(int precision, int scale);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Float"/>
        /// </summary>
        NullableSingleCastFunctionExpression AsFloat();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.UniqueIdentifier"/>
        /// </summary>
        NullableGuidCastFunctionExpression AsUniqueIdentifier();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.SmallInt"/>
        /// </summary>
        NullableInt16CastFunctionExpression AsSmallInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Int"/>
        /// </summary>
        NullableInt32CastFunctionExpression AsInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.BigInt"/>
        /// </summary>
        NullableInt64CastFunctionExpression AsBigInt();

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.VarChar"/>
        /// </summary>
        NullableStringCastFunctionExpression AsVarChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Char"/>
        /// </summary>
        NullableStringCastFunctionExpression AsChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.NVarChar"/>
        /// </summary>
        NullableStringCastFunctionExpression AsNVarChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.NChar"/>
        /// </summary>
        NullableStringCastFunctionExpression AsNChar(int size);

        /// <summary>
        /// Convert the sql type to a <see cref="SqlDbType.Time"/>
        /// </summary>
        NullableTimeSpanCastFunctionExpression AsTime();
    }
}
