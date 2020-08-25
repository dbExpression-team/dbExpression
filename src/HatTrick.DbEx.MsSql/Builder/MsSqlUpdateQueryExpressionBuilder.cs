using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlUpdateQueryExpressionBuilder : UpdateQueryExpressionBuilder
    {
        public new UpdateQueryExpression Expression => base.Expression as UpdateQueryExpression;

        public MsSqlUpdateQueryExpressionBuilder(RuntimeSqlDatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>())
        { 
        
        }

        protected override IUpdateContinuationExpressionBuilder<U> CreateTypedBuilder<U>(RuntimeSqlDatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<U> entity)
        {
            return new MsSqlUpdateQueryExpressionBuilder<U>(configuration, expression, entity);
        }
    }
}