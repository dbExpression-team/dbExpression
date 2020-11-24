using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Limit<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        TCaller Limit(int value);
        TCaller Having(AnyHavingClause having);
    }
}
