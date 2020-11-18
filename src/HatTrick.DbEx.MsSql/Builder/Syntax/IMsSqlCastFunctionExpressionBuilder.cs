using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder.Syntax
{
    public interface IMsSqlCastFunctionExpressionBuilder : ICastFunctionExpressionBuilder
    {
        DoubleCastFunctionExpression AsMoney();
        DoubleCastFunctionExpression AsSmallMoney();
    }
}
