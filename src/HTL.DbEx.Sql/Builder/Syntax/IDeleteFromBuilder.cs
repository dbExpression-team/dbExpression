using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IDeleteFromBuilder : IBuilder
    {
        IDeleteContinuationBuilder From(DBExpressionEntity entity);
    }
}
