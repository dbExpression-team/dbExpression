using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Assembler
{
    public interface ISqlStatementBuilderFactory
    {
        ISqlStatementBuilder CreateSqlStatementBuilder(
            SqlStatementAssemblerConfiguration config,
            QueryExpression expression, 
            IAppender appender,
            ISqlParameterBuilder parameterBuilder
        );
    }
}
