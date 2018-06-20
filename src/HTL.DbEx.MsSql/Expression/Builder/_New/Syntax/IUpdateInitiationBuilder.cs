using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IUpdateInitiationBuilder : IBuilder
    {
        IUpdateContinuationBuilder Update(DBAssignmentExpression[] assignments);
    }
}
