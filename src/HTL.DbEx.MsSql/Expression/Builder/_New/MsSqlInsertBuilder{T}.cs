using HTL.DbEx.Sql;
using HTL.DbEx.Sql.Expression;

namespace HTL.DbEx.MsSql.Expression._New
{
    public class MsSqlInsertBuilder<T> : SqlInsertBuilder<T>
        where T : class, IDBEntity
    {
        public MsSqlInsertBuilder(DBExpressionSet expression) : base(expression)
        { }
    }
}