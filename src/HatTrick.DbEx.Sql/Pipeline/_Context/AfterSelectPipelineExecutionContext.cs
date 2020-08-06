using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterSelectPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public SqlStatement Statement { get; private set; }

        public AfterSelectPipelineExecutionContext(DatabaseConfiguration database, SelectQueryExpression expression, SqlStatement statement)
            : base(database, expression)
        {
            Statement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
        }
    }
}
