using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlDeleteSqlExpressionBuilder : DeleteSqlExpressionBuilder
    {
        public new DeleteQueryExpression Expression => base.Expression as DeleteQueryExpression;

        public MsSqlDeleteSqlExpressionBuilder(DatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<DeleteQueryExpression>())
        { }
    }
}