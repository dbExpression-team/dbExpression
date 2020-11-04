using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlUpdateQueryExpressionBuilder<T> : UpdateQueryExpressionBuilder<T>
        where T : class, IDbEntity
    {
        public MsSqlUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<T> entity)
            : base(configuration, expression, entity)
        {

        }

        public MsSqlUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, T target, T source)
            : base(configuration, expression, target, source)
        {

        }

        protected override IUpdateContinuationExpressionBuilder<U> CreateTypedBuilder<U>(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<U> entity)
        {
            Expression.BaseEntity = entity;
            return this as IUpdateContinuationExpressionBuilder<U>;
        }
    }
}
