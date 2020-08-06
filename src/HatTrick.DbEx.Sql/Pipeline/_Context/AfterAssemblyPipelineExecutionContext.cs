using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public ISqlStatementBuilder SqlStatementBuilder { get; private set; }

        public AfterAssemblyPipelineExecutionContext(DatabaseConfiguration database, QueryExpression expression, ISqlStatementBuilder builder)
            : base(database, expression)
        {
            SqlStatementBuilder = builder;
        }
    }
}
