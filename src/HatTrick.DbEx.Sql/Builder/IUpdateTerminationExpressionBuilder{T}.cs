namespace HatTrick.DbEx.Sql.Builder
{
    public interface IUpdateTerminationExpressionBuilder<T> : ITerminationExpressionBuilder
        where T : class, IDbEntity
    {
    }
}
