using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeExecutionPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public SqlStatement Statement { get; private set; }
        public IDbCommand DbCommand { get; private set; }

        public BeforeExecutionPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression, SqlStatement statement, IDbCommand command)
            : base(database, expression)
        {
            Statement = statement ?? throw new ArgumentNullException($"{nameof(statement)} is required.");
            DbCommand = command ?? throw new ArgumentNullException($"{nameof(command)} is required.");
        }
    }
}
