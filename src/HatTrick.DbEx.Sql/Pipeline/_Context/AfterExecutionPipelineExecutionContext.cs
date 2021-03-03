using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Data.Common;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterExecutionPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public IDbCommand DbCommand { get; private set; }

        public AfterExecutionPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression, IDbCommand command)
            : base(database, expression)
        {
            DbCommand = command ?? throw new ArgumentNullException(nameof(command));
        }
    }
}
