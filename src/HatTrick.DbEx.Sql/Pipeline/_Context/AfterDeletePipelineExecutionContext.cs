using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterDeletePipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public AfterDeletePipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, DeleteQueryExpression expression)
            : base(database, expression)
        {

        }
    }
}
