using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.Sql.Builder.Syntax
{
    public interface IInsertBuilder<T> : IContinuationBuilder<T>
        where T : class, IDBEntity
    {
        ITerminationBuilder Into<U>(U entity)
            where U : DBExpressionEntity<T>;
    }
}
