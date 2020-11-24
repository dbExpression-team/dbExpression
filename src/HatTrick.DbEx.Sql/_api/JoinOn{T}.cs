using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JoinOn<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        TCaller On(AnyJoinOnClause joinOn);
    }
}
