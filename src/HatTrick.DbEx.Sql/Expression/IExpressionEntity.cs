namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionEntity : IExpressionElement
    {
        SelectExpressionSet BuildInclusiveSelectExpression();
    }
}
