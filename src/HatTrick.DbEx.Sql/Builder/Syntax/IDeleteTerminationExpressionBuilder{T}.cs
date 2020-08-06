namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IDeleteTerminationExpressionBuilder<T> : ITerminationExpressionBuilder
        where T : class, IDbEntity
    {
    }
}
