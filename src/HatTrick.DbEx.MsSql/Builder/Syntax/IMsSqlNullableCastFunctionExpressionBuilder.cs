using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder.Syntax
{
    public interface IMsSqlNullableCastFunctionExpressionBuilder : INullableCastFunctionExpressionBuilder
    {
        NullableDoubleCastFunctionExpression AsMoney();
        NullableDoubleCastFunctionExpression AsSmallMoney();
    }
}
