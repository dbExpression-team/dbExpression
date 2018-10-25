using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HatTrick.DbEx.Sql.Configuration
{
    public static class DbExpressionConfiguration
    {
        public static IList<ConnectionStringSettings> ConnectionStringSettings { get; set; } = new List<ConnectionStringSettings>();
        public static ISqlStatementBuilderFactory StatementBuilderFactory { get; set; }
        public static ISqlParameterBuilderFactory ParameterBuilderFactory { get; set; }
        public static ISqlStatementExecutorFactory ExecutorFactory { get; set; }
        public static ISqlConnectionFactory ConnectionFactory { get; set; }
        public static IMapperFactory MapperFactory { get; set; }

        public static DbExpressionAssemblerConfiguration AssemblerConfiguration { get; set; } = new DbExpressionAssemblerConfiguration();
    }
}
