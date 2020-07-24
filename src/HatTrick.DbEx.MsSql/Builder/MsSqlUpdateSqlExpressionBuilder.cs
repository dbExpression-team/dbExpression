using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlUpdateSqlExpressionBuilder : UpdateSqlExpressionBuilder
    {
        public new UpdateQueryExpression Expression => base.Expression as UpdateQueryExpression;

        public MsSqlUpdateSqlExpressionBuilder(DatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>())
        { }
    }
}