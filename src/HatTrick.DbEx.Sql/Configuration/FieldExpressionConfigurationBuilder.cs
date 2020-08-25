using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class FieldExpressionConfigurationBuilder : IFieldExpressionConfigurationBuilder
    {
        private RuntimeSqlDatabaseConfiguration config;

        public FieldExpressionConfigurationBuilder(RuntimeSqlDatabaseConfiguration config)
        {
            this.config = config;
        }

        public IFieldExpressionConfigurationContinuationBuilder<T> For<T>(FieldExpression<T> field)
            where T : IComparable
        {
            return new FieldExpressionConfigurationBuilder<T>(config, field);
        }
    }
}
