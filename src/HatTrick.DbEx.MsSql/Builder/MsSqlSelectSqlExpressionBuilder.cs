using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{

    public partial class MsSqlSelectSqlExpressionBuilder : SelectSqlExpressionBuilder
    {
        #region constructors
        public MsSqlSelectSqlExpressionBuilder(DatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<SelectQueryExpression>())
        {

        }

        public MsSqlSelectSqlExpressionBuilder(DatabaseConfiguration configuration, SelectQueryExpression expression) : base(configuration, expression)
        {

        }
        #endregion
    }
}
