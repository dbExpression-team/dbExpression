using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IValueListFromBuilder<T, U> : IContinuationBuilder<T>
             where U : class, IValueListContinuationBuilder<T>
    {
        IValueListContinuationBuilder<T, U> From(DBExpressionEntity entity);
    }
}
