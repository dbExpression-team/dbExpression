using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class DatabaseConfiguration
    {
        #region interface
        public ISqlDatabaseMetadata Metadata { get; }
        public ExecutionPipelineFactory ExecutionPipelineFactory { get; set; }
        public ISqlStatementBuilderFactory StatementBuilderFactory { get; set; }
        public IAppenderFactory AppenderFactory { get; set; }
        public ISqlParameterBuilderFactory ParameterBuilderFactory { get; set; }
        public ISqlStatementExecutorFactory ExecutorFactory { get; set; }
        public ISqlConnectionFactory ConnectionFactory { get; set; }
        public IMapperFactory MapperFactory { get; set; }
        public IEntityFactory EntityFactory { get; set; }
        public DbExpressionAssemblerConfiguration AssemblerConfiguration { get; set; } = new DbExpressionAssemblerConfiguration();
        #endregion

        #region constructors
        public DatabaseConfiguration(IDatabaseMetadataProvider provider)
        {
            Metadata = provider.Database;
        }
        #endregion
    }
}
