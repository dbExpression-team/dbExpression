using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeDeletePipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public IAppender CommandTextWriter { get; private set; }

        public BeforeDeletePipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, DeleteQueryExpression expression, IAppender appender, ISqlParameterBuilder parameterBuilder)
            : base(database, expression)
        {
            CommandTextWriter = appender ?? throw new ArgumentNullException($"{nameof(appender)} is required.");
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
        }
    }
}
