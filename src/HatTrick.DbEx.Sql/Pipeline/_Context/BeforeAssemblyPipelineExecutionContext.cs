using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public BeforeAssemblyPipelineExecutionContext(RuntimeSqlDatabaseConfiguration database, QueryExpression expression)
            : base(database, expression)
        {
        }
    }
}
