using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface NullableCast
#pragma warning restore IDE1006 // Naming Styles
    {
        NullableBooleanCastFunctionExpression AsBit();
        NullableByteCastFunctionExpression AsTinyInt();
        NullableDateTimeCastFunctionExpression AsDateTime();
        NullableDateTimeOffsetCastFunctionExpression AsDateTimeOffset();
        NullableDecimalCastFunctionExpression AsDecimal(int precision, int scale);
        NullableSingleCastFunctionExpression AsFloat();
        NullableGuidCastFunctionExpression AsUniqueIdentifier();
        NullableInt16CastFunctionExpression AsSmallInt();
        NullableInt32CastFunctionExpression AsInt();
        NullableInt64CastFunctionExpression AsBigInt();
        StringCastFunctionExpression AsVarChar(int size);
        StringCastFunctionExpression AsChar(int size);
        StringCastFunctionExpression AsNVarChar(int size);
        StringCastFunctionExpression AsNChar(int size);
        NullableTimeSpanCastFunctionExpression AsTime();
    }
}
