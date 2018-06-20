using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IUpdateFromBuilder : IContinuationBuilder
    {
        IUpdateContinuationBuilder From(DBExpressionEntity entity);
    }
}
