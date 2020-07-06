namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbAssignmentExpressionProvider
    {
        ExpressionMediator Assignee { get; }
        ExpressionMediator Assignment { get; }
    }
}
