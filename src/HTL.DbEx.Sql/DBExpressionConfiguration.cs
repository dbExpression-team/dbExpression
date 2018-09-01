using HTL.DbEx.Sql.Assembler;
using HTL.DbEx.Sql.Connection;
using HTL.DbEx.Sql.Executor;
using HTL.DbEx.Sql.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace HTL.DbEx.Sql
{
    public static class DBExpressionConfiguration
    {
        public static IList<ConnectionStringSettings> ConnectionStringSettings { get; set; } = new List<ConnectionStringSettings>();
        public static ISqlStatementBuilderFactory StatementBuilderFactory { get; set; }
        public static ISqlParameterBuilderFactory ParameterBuilderFactory { get; set; }
        public static ISqlExecutorFactory ExecutorFactory { get; set; }
        public static ISqlConnectionFactory ConnectionFactory { get; set; }
        public static IMapperFactory MapperFactory { get; set; }

        public static bool Minify { get; set; } = true;
    }
}
