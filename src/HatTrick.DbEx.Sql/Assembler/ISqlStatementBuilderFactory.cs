using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilderFactory
    {
        ISqlStatementBuilder CreateSqlStatementBuilder(
            ISqlDatabaseMetadataProvider databaseMetadata,
            IExpressionElementAppenderFactory partAppenderFactory,
            SqlStatementAssemblerConfiguration config,
            QueryExpression expression,
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        );
    }
}
