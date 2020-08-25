using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class FieldExpressionConfigurationBuilder<T> : IFieldExpressionConfigurationContinuationBuilder<T>
    {
        private RuntimeSqlDatabaseConfiguration config;
        private FieldExpression<T> field;

        public FieldExpressionConfigurationBuilder(RuntimeSqlDatabaseConfiguration config, FieldExpression<T> field)
        {
            this.config = config;
            this.field = field;
        }

        public void UseConverter<U>()
            where U : class, IValueConverter, new()
        {
            config.ValueConverterFactory.RegisterConverter(new U(), field);
        }

        public void UseConverter(IValueConverter converter)
        {
            config.ValueConverterFactory.RegisterConverter(converter, field);
        }
    }
}
