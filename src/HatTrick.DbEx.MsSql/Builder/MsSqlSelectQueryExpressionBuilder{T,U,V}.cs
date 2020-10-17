using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlSelectQueryExpressionBuilder<T, U, V> : SelectQueryExpressionBuilder<T, U, V>,
        IQueryExpressionProvider<SelectQueryExpression>
        where U : class, IContinuationExpressionBuilder<T>
        where V : class, IContinuationExpressionBuilder<T, U>
    {
        public new SelectQueryExpression Expression => base.Expression as SelectQueryExpression;

        public MsSqlSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory?.CreateQueryExpression<SelectQueryExpression>())
        {

        }
    }
}
