using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlStatementBuilder SqlStatementBuilder { get; private set; }

        public AfterAssemblyPipelineExecutionContext(QueryExpression expression, ISqlStatementBuilder builder)
            : base(expression)
        {
            SqlStatementBuilder = builder;
        }
    }
}
