using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface ICastFunctionExpressionBuilder
    {
        CastFunctionExpression<bool> AsBit();
        CastFunctionExpression<byte> AsTinyInt();
        CastFunctionExpression<DateTime> AsDateTime();
        CastFunctionExpression<DateTimeOffset> AsDateTimeOffset();
        CastFunctionExpression<decimal> AsDecimal(int precision, int scale);
        CastFunctionExpression<float> AsFloat();
        CastFunctionExpression<Guid> AsUniqueIdentifier();
        CastFunctionExpression<short> AsSmallInt();
        CastFunctionExpression<int> AsInt();
        CastFunctionExpression<long> AsBigInt();
        CastFunctionExpression<string> AsVarChar(int size);
        CastFunctionExpression<string> AsChar(int size);
        CastFunctionExpression<string> AsNVarChar(int size);
        CastFunctionExpression<string> AsNChar(int size);
    }
}
