using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlDeleteQueryExpressionBuilder : DeleteQueryExpressionBuilder
    {
        public MsSqlDeleteQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression) : base(configuration, expression)
        { }

        protected override IDeleteContinuationExpressionBuilder<T> CreateTypedBuilder<T>(RuntimeSqlDatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<T> entity)
        {
            return new MsSqlDeleteQueryExpressionBuilder<T>(Configuration, expression, entity);
        }
    }
}