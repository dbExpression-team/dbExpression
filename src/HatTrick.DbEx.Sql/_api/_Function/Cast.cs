using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Cast
#pragma warning restore IDE1006 // Naming Styles
    {
        BooleanCastFunctionExpression AsBit();
        ByteCastFunctionExpression AsTinyInt();
        DateTimeCastFunctionExpression AsDateTime();
        DateTimeOffsetCastFunctionExpression AsDateTimeOffset();
        DecimalCastFunctionExpression AsDecimal(int precision, int scale);
        SingleCastFunctionExpression AsFloat();
        GuidCastFunctionExpression AsUniqueIdentifier();
        Int16CastFunctionExpression AsSmallInt();
        Int32CastFunctionExpression AsInt();
        Int64CastFunctionExpression AsBigInt();
        StringCastFunctionExpression AsVarChar(int size);
        StringCastFunctionExpression AsChar(int size);
        StringCastFunctionExpression AsNVarChar(int size);
        StringCastFunctionExpression AsNChar(int size);
        TimeSpanCastFunctionExpression AsTime();
    }
}
