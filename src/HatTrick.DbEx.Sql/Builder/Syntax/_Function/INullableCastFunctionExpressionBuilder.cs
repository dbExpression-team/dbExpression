using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface INullableCastFunctionExpressionBuilder
    {
        NullableCastFunctionExpression<bool?> AsBit();
        NullableCastFunctionExpression<byte?> AsTinyInt();
        NullableCastFunctionExpression<DateTime?> AsDateTime();
        NullableCastFunctionExpression<DateTimeOffset?> AsDateTimeOffset();
        NullableCastFunctionExpression<decimal?> AsDecimal(int precision, int scale);
        NullableCastFunctionExpression<float?> AsFloat();
        NullableCastFunctionExpression<Guid?> AsUniqueIdentifier();
        NullableCastFunctionExpression<short?> AsSmallInt();
        NullableCastFunctionExpression<int?> AsInt();
        NullableCastFunctionExpression<long?> AsBigInt();
        NullableCastFunctionExpression<string> AsVarChar(int size);
        NullableCastFunctionExpression<string> AsChar(int size);
        NullableCastFunctionExpression<string> AsNVarChar(int size);
        NullableCastFunctionExpression<string> AsNChar(int size);
    }
}
