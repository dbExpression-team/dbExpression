using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterDeletePipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public SqlStatement Statement { get; private set; }

        public AfterDeletePipelineExecutionContext(DatabaseConfiguration database, DeleteQueryExpression expression, SqlStatement statement)
            : base(database, expression)
        {
            Statement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
        }
    }
}
