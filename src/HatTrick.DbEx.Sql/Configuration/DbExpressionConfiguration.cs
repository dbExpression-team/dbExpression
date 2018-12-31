using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Configuration
{
    public static class DbExConfigurationSettings
    {
        public static DbExpressionConfiguration Settings { get; set; }
    }

    public class DbExpressionConfiguration
    {
        public IDictionary<string, ConnectionStringSettings> ConnectionStringSettings { get; set; } = new Dictionary<string,ConnectionStringSettings>();
        public ISqlStatementBuilderFactory StatementBuilderFactory { get; set; }
        public IAppenderFactory AppenderFactory { get; set; }
        public ISqlParameterBuilderFactory ParameterBuilderFactory { get; set; }
        public ISqlStatementExecutorFactory ExecutorFactory { get; set; }
        public ISqlConnectionFactory ConnectionFactory { get; set; }
        public IMapperFactory MapperFactory { get; set; }
        public IEntityFactory EntityFactory { get; set; }
        public IDatabaseMetadataProvider Metadata { get; set; }

        public DbExpressionAssemblerConfiguration AssemblerConfiguration { get; set; } = new DbExpressionAssemblerConfiguration();
    }
}
