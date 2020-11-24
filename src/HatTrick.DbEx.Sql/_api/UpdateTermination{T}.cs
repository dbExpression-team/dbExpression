using HatTrick.DbEx.Sql.Builder;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateTermination<T> : IUpdateTerminationExpressionBuilder<T>
#pragma warning restore IDE1006 // Naming Styles
        where T : class, IDbEntity
    {
    }
}
