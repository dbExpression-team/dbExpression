using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface INullableCastFunctionExpressionBuilder
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
