using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeExecutionPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public IDbCommand DbCommand { get; private set; }
        public SqlStatement Statement { get; private set; }

        public BeforeExecutionPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression, IDbCommand command, SqlStatement statement)
            : base(database, expression)
        {
            DbCommand = command ?? throw new ArgumentNullException($"{nameof(command)} is required.");
            Statement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
        }
    }
}
