namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateTerminationExpressionBuilder<T> : ITerminationExpressionBuilder
        where T : class, IDbEntity
    {
    }
}
