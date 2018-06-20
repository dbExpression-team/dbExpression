using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IDeleteFromBuilder : IBuilder
    {
        IDeleteContinuationBuilder From(DBExpressionEntity entity);
    }
}
