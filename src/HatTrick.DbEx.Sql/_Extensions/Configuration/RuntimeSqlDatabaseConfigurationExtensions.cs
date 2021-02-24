using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Configuration
{
    public static class RuntimeSqlDatabaseConfigurationExtensions
    {
        public static void Validate(this RuntimeSqlDatabaseConfiguration configuration)
        {
            if (!configuration.TryValidate(out List<string> validationErrors))
                throw new DbExpressionConfigurationException($"Database configuration is not valid.  The following factories/providers have not been configured: {string.Join(", ", validationErrors)}.");
        }

        public static bool TryValidate(this RuntimeSqlDatabaseConfiguration configuration, out List<string> validationErrors)
        {
            var validations = new List<string>();
            try
            {
                void addIfNull(string configProperty, object configurationItem) { if (configurationItem is null) validations.Add(configProperty); }

                addIfNull(nameof(configuration.AppenderFactory), configuration.AppenderFactory);
                addIfNull(nameof(configuration.ConnectionFactory), configuration.ConnectionFactory);
                addIfNull(nameof(configuration.ConnectionStringFactory), configuration.ConnectionStringFactory);
                addIfNull(nameof(configuration.EntityFactory), configuration.EntityFactory);
                addIfNull(nameof(configuration.ExecutionPipelineFactory), configuration.ExecutionPipelineFactory);
                addIfNull(nameof(configuration.ExpressionElementAppenderFactory), configuration.ExpressionElementAppenderFactory);
                addIfNull(nameof(configuration.MapperFactory), configuration.MapperFactory);
                addIfNull(nameof(configuration.MetadataProvider), configuration.MetadataProvider);
                addIfNull(nameof(configuration.ParameterBuilderFactory), configuration.ParameterBuilderFactory);
                addIfNull(nameof(configuration.QueryExpressionFactory), configuration.QueryExpressionFactory);
                addIfNull(nameof(configuration.StatementBuilderFactory), configuration.StatementBuilderFactory);
                addIfNull(nameof(configuration.StatementExecutorFactory), configuration.StatementExecutorFactory);
                addIfNull(nameof(configuration.ValueConverterFactory), configuration.ValueConverterFactory);
            }
            catch
            {
                validationErrors = validations;
                return false;
            }

            validationErrors = validations;
            return !validationErrors.Any();
        }
    }
}
