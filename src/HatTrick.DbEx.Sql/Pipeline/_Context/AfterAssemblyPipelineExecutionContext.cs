using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public class AfterAssemblyPipelineExecutionContext : PipelineExecutionContext, IPipelineExecutionContext
    {
        public FilteredFields InsertFields { get; private set; }
        public AllFields AllFields { get; private set; }

        public ISqlStatementBuilder SqlStatementBuilder { get; private set; }

        public AfterAssemblyPipelineExecutionContext(ExpressionSet expression, ISqlStatementBuilder builder)
            : base(expression)
        {
            InsertFields = new FilteredFields(expression, SqlStatementExecutionType.Insert);
            AllFields = new AllFields(expression, SqlStatementExecutionType.Insert);
            SqlStatementBuilder = builder;
        }
    }
}
