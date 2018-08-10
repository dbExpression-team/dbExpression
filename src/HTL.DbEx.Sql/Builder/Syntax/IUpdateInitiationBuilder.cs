using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateInitiationBuilder : IBuilder
    {
        IUpdateContinuationBuilder Update(DBAssignmentExpression[] assignments);
    }
}
