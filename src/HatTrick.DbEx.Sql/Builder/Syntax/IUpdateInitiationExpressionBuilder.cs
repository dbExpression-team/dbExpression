using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateInitiationExpressionBuilder : 
        IExpressionBuilder
    {
        IUpdateFromExpressionBuilder Update(AssignmentExpression[] assignments);
    }
}
