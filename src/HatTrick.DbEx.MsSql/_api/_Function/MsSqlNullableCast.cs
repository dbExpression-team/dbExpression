using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface MsSqlNullableCast : NullableCast
#pragma warning restore IDE1006 // Naming Styles
    {
        NullableDoubleCastFunctionExpression AsMoney();
        NullableDoubleCastFunctionExpression AsSmallMoney();
    }
}
