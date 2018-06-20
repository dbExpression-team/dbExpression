using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class SqlInsertBuilder<T> : SqlBuilder<T>, 
        IInsertBuilder<T>, 
        ITerminationBuilder<T>, 
        IBuilder<T>
        where T : class, IDBEntity
    {
        public SqlInsertBuilder(DBExpressionSet expression) : base(expression)
        {
        }

        ITerminationBuilder<T> IInsertBuilder<T>.Into<U>(U entity)
        {
            Expression.BaseEntity = entity;
            return this;
        }
    }
}
