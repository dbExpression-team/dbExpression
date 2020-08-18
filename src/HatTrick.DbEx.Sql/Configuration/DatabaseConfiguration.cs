using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Converter;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DatabaseConfiguration
    {
        #region interface
        public IQueryExpressionFactory QueryExpressionFactory { get; set; }
        public IExecutionPipelineFactory ExecutionPipelineFactory { get; set;  }
        public ISqlStatementBuilderFactory StatementBuilderFactory { get; set; }
        public IAppenderFactory AppenderFactory { get; set; }
        public ISqlParameterBuilderFactory ParameterBuilderFactory { get; set; }
        public ISqlStatementExecutorFactory ExecutorFactory { get; set; }
        public ISqlConnectionFactory ConnectionFactory { get; set; }
        public IMapperFactory MapperFactory { get; set; }
        public IEntityFactory EntityFactory { get; set; }
        public IValueConverterFactory ValueConverterFactory { get; set; }
        public SqlStatementAssemblerConfiguration AssemblerConfiguration { get; set; } = new SqlStatementAssemblerConfiguration();
        #endregion
    }
}
