using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlDeleteSqlExpressionBuilder : DeleteSqlExpressionBuilder
    {
        public MsSqlDeleteSqlExpressionBuilder(DatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<DeleteQueryExpression>())
        { }

        protected override IDeleteContinuationExpressionBuilder<T> CreateTypedBuilder<T>(DatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<T> entity)
        {
            return new MsSqlDeleteExpressionBuilder<T>(Configuration, expression, entity);
        }
    }
}