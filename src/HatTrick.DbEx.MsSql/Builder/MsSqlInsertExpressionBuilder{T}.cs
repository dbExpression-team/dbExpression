using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlInsertSqlExpressionBuilder<T> : InsertSqlExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public new InsertQueryExpression Expression => base.Expression as InsertQueryExpression;

        public MsSqlInsertSqlExpressionBuilder(DatabaseConfiguration configuration, T instance) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<InsertQueryExpression>())
        {
            Expression.Instance = instance ?? throw new ArgumentNullException($"{nameof(instance)} is required.");
        }
    }
}