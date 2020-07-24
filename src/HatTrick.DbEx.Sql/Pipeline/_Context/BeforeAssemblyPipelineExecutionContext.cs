using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class BeforeAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public BeforeAssemblyPipelineExecutionContext(QueryExpression expression)
            : base(expression)
        {
        }
    }
}
