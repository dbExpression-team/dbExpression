using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IUpdateFromBuilder : IContinuationBuilder
    {
        IUpdateContinuationBuilder From(DBExpressionEntity entity);
    }
}
