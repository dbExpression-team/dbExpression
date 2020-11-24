using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface MsSqlCast : Cast
#pragma warning restore IDE1006 // Naming Styles
    {
        DoubleCastFunctionExpression AsMoney();
        DoubleCastFunctionExpression AsSmallMoney();
    }
}
