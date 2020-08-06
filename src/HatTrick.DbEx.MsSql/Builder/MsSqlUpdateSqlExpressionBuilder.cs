using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder
{
    public class MsSqlUpdateSqlExpressionBuilder : UpdateSqlExpressionBuilder
    {
        public new UpdateQueryExpression Expression => base.Expression as UpdateQueryExpression;

        public MsSqlUpdateSqlExpressionBuilder(DatabaseConfiguration configuration) : base(configuration, configuration.QueryExpressionFactory.CreateQueryExpression<UpdateQueryExpression>())
        { 
        
        }

        protected override IUpdateContinuationExpressionBuilder<U> CreateTypedBuilder<U>(DatabaseConfiguration configuration, UpdateQueryExpression expression, EntityExpression<U> entity)
        {
            return new MsSqlUpdateSqlExpressionBuilder<U>(configuration, expression, entity);
        }
    }
}