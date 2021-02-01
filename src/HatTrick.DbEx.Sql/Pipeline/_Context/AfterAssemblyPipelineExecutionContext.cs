using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public SqlStatement SqlStatement { get; private set; }

        public AfterAssemblyPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression, ISqlParameterBuilder parameterBuilder, SqlStatement statement)
            : base(database, expression)
        {
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
            SqlStatement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required to construct a pipeline execution context.");
        }
    }
}
