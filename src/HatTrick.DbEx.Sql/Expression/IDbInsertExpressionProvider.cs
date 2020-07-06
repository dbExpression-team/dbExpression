namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbInsertExpressionProvider
    {
        FieldExpression Assignee { get; }
        ExpressionMediator Assignment { get; }
    }
}
