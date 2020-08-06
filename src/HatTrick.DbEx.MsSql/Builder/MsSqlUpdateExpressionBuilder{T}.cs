using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlUpdateSqlExpressionBuilder<T> : UpdateSqlExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public MsSqlUpdateSqlExpressionBuilder(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity)
            : base(configuration, expression, entity)
        {

        }

        protected override IUpdateContinuationExpressionBuilder<U> CreateTypedBuilder<U>(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<U> entity)
        {
            return new MsSqlUpdateSqlExpressionBuilder<U>(configuration, expression, entity);
        }
    }
}
