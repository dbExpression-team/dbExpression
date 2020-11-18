namespace HatTrick.DbEx.Sql.Expression
{
    public interface IAssignmentExpressionProvider
    {
        FieldExpression Assignee { get; }
        IExpressionElement Assignment { get; }
    }
}
