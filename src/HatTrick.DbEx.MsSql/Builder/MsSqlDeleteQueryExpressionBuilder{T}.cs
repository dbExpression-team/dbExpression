using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlDeleteQueryExpressionBuilder<T> : DeleteQueryExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public MsSqlDeleteQueryExpressionBuilder(DatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<T> entity)
            : base(configuration, expression, entity)
        {

        }

        protected override IDeleteContinuationExpressionBuilder<U> CreateTypedBuilder<U>(DatabaseConfiguration configuration, DeleteQueryExpression expression, EntityExpression<U> entity)
        {
            return new MsSqlDeleteQueryExpressionBuilder<U>(configuration, expression, entity);
        }
    }
}
