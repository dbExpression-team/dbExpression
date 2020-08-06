namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IInsertTerminationExpressionBuilder<T> : ITerminationExpressionBuilder
        where T : class, IDbEntity
    {
    }
}
