namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbAssignmentExpressionProvider
    {
        FieldExpression Assignee { get; }
        ExpressionMediator Assignment { get; }
    }
}
