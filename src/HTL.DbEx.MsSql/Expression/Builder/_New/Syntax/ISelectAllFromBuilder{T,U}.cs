using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface ISelectAllFromBuilder<T, U> : IContinuationBuilder<T>
             where U : class, ISelectAllContinuationBuilder<T>
    {
        ISelectAllContinuationBuilder<T, U> From(DBExpressionEntity entity);
    }
}
