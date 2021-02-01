using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterSelectPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public AfterSelectPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, SelectQueryExpression expression)
            : base(database, expression)
        {

        }
    }
}
