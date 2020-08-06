namespace HatTrick.DbEx.Sql.Expression
{
    public interface IAssignmentExpressionProvider
    {
        FieldExpression Assignee { get; }
        ExpressionMediator Assignment { get; }
    }
}
