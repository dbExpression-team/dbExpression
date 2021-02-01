using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeSelectPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlParameterBuilder ParameterBuilder { get; private set; }
        public SqlStatement SqlStatement { get; private set; }

        public BeforeSelectPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, SelectQueryExpression expression, SqlStatement statement, ISqlParameterBuilder parameterBuilder)
            : base(database, expression)
        {
            SqlStatement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
            ParameterBuilder = parameterBuilder ?? throw new ArgumentNullException($"{nameof(parameterBuilder)} is required.");
        }
    }
}
