using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{

    public partial class MsSqlSelectQueryExpressionBuilder : SelectQueryExpressionBuilder
    {
        #region constructors
        public MsSqlSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>())
        {

        }

        public MsSqlSelectQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        {

        }
        #endregion
    }
}
