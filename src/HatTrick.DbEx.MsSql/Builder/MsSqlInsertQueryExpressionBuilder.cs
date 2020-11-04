using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlInsertQueryExpressionBuilder<T> : InsertQueryExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public MsSqlInsertQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, InsertQueryExpression expression, IEnumerable<T> instances) : base(configuration, instances, expression)
        {
        }
    }
}