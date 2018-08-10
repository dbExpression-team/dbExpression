using HTL.DbEx.Sql.Builder;
using HTL.DbEx.Sql.Builder.Syntax;
using HTL.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HTL.DbEx.MsSql.Builder
{
    public class MsListSqlBuilder<T, U, V> : ListSqlBuilder<T, U, V>
        where U : class, IContinuationBuilder<T>
        where V : class, IContinuationBuilder<T, U>
    {
        public MsListSqlBuilder(DBExpressionSet expression) : base(expression)
        {
        }
    }
}
