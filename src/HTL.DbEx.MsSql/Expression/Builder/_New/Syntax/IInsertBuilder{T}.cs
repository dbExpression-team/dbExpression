using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public interface IInsertBuilder<T> : IContinuationBuilder<T>
        where T : class, IDBEntity
    {
        ITerminationBuilder<T> Into<U>(U entity)
            where U : DBExpressionEntity<T>;
    }
}
